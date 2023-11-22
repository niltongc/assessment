namespace UDPClient.Handlers
{
    public class MessageHandler
    {
        public string AutomaticMessage()
        {
            //Generate automatic radom message
            var randomNumberGenerator = new Random();
            int RandomType = randomNumberGenerator.Next(100);

            string TypeData = "";

            if (RandomType > 50)
            {
                TypeData = "DATA1";
            }
            else
            {
                TypeData = "DATA2";
            }

            int RandomProtocol = randomNumberGenerator.Next(100);
            string ProtocolData = ""; 

            if (RandomProtocol > 67)
            {
                ProtocolData = "66";
            }
            else if (RandomProtocol > 33)
            {
                ProtocolData = "67";
            } else 
            {
                ProtocolData = "68";
            }

            string DateNow = DateTime.UtcNow.ToString("yyMMddhhmmss");

            string StatusData = ""; 
            int RandomStatus = randomNumberGenerator.Next(100);

            if (RandomStatus > 50)
            {
                StatusData = "1";
            }
            else 
            {
                StatusData = "0";
            }

          
            int RandomId = randomNumberGenerator.Next(100, 999);
            string IdData = $"ID={RandomId}";

            string result = TypeData + "," + ProtocolData + "," + DateNow + "," + StatusData + "," + IdData ;
            return result;
        }
    }
}
