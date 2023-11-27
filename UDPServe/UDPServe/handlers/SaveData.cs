using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;
using UDPServe.Models;
using UDPServe.Validation;


namespace UDPServe.Handlers
{

    public class SaveData
    {
        const string masterConnectionString = "Server=localhost\\SQLEXPRESS01;Integrated Security=True; TrustServerCertificate=True";
        const string connectionString = "Server=localhost\\SQLEXPRESS01;DataBase=DevStatus;Integrated Security=True; TrustServerCertificate=True";

        public static void SaveInDatabase(string message)
        {
            try
            {
                message = ConvertRemoveChar.RemoveChar(message);

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Split Message
                    string[] parts = message.Split(",");

                    // Data type
                    string data1 = DataTypeValidation.IsCorrectData(parts[0]);
                    int dataNumber = int.Parse(data1.Substring(data1.Length - 1));

                    // Protocol
                    string protocoloPart = DataTypeValidation.IsCorrectProtocol(parts[1]);

                    // DateTime
                    string utcPart = DataTypeValidation.IsCorrectDate(parts[2]);
                    var utcConverted = ConvertDate.ConvertDateTime(utcPart);

                    // Status
                    string statusPart = DataTypeValidation.IsCorrectStatus(parts[3]);

                    // Id
                    string idPart = DataTypeValidation.IsCorrectId(parts[4].Substring(3));

                    // Verify if Primary key exists
                    bool existingRecord = IdVerify(idPart);

                    if (existingRecord)
                    {
                        System.Console.WriteLine("It's not possible to save: PRIMARY KEY already exists");
                        return;
                    }

                    // Insert data in Database
                    var command = new SqlCommand("INSERT INTO dev_status (type, protocolo, utc, status, id) VALUES (@type, @protocolo, @utc, @status, @id)", connection);
                    command.Parameters.AddWithValue("@type", dataNumber);
                    command.Parameters.AddWithValue("@protocolo", protocoloPart);
                    command.Parameters.AddWithValue("@utc", utcConverted);
                    command.Parameters.AddWithValue("@status", statusPart);
                    command.Parameters.AddWithValue("@id", idPart);

                    command.ExecuteNonQuery();

                    connection.Close();

                    // Parsing DateTime to string formatted
                    var utcFormatted = utcConverted.ToString("yyyy-MM-dd HH:mm:ss");

                    // Call function to save Json
                    SaveJson(dataNumber, protocoloPart, utcFormatted, statusPart, idPart);
                }
            }
            catch (ArgumentException ex)
            {
                System.Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions as needed
                System.Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void CreateDatabaseAndTableIfNotExists()
        {

            using (var connection = new SqlConnection(masterConnectionString))
            {

                connection.Open();



                var checkDatabaseCommand = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = 'DevStatus'", connection);
                int databaseExists = (int)checkDatabaseCommand.ExecuteScalar();

                if (databaseExists == 0)
                {
                    System.Console.WriteLine("DatabaseCreate Init");
                    var createDatabaseCommand = new SqlCommand("CREATE DATABASE DevStatus", connection);
                    createDatabaseCommand.ExecuteNonQuery();
                }

                connection.ChangeDatabase("DevStatus");

                var checkTableCommand = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'dev_status'", connection);
                int tableExists = (int)checkTableCommand.ExecuteScalar();

                if (tableExists == 0)
                {
                    var createTableCommand = new SqlCommand(
                        @"CREATE TABLE dev_status
                (
                    Id NVARCHAR(4) PRIMARY KEY,
                    Type INT NOT NULL,
                    Protocolo INT NOT NULL,
                    UTC DATETIME NOT NULL,
                    Status INT NOT NULL
                )", connection);

                    createTableCommand.ExecuteNonQuery();
                    System.Console.WriteLine("Database and Table Created");
                }
                connection.Close();
            }


        }

        public static bool IdVerify(string id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = new SqlCommand("SELECT COUNT(*) FROM dev_status dv WHERE dv.id=@id", connection);
                command.Parameters.AddWithValue("@id", id);

                int count = (int)command.ExecuteScalar();

                connection.Close();


                return count > 0;
            }

        }

        // Saving Json
        public static void SaveJson(int dataNumber, string protocoloPart,
        string utcPart, string statusPart, string idPart)
        {
            var Data = new JsonModel()
            {
                Type = dataNumber,
                Protocolo = int.Parse(protocoloPart),
                Utc = utcPart,
                Status = int.Parse(statusPart),
                Id = idPart
            };

            string json = JsonSerializer.Serialize(Data);

            string directoryPath = "json";
            string filePath = Path.Combine(directoryPath, $"{idPart}.json"); // Caminho completo do arquivo

            // Create Directory if not exists
            Directory.CreateDirectory(directoryPath);

            File.WriteAllText(filePath, json);

            System.Console.WriteLine("Json saved");
        }




    }



}