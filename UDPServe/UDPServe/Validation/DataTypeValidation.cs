
namespace UDPServe.Validation
{

    public class DataTypeValidation
    {

        public static string IsCorrectData(string data)
        {
            
            var data2 = data.Substring(1);
           
            if (data2 != "DATA1" && data2 != "DATA2")
            {
                throw new ArgumentException("The type is not in formated like DATA1 or DATA2");
            }
            
            return data;
        }

        public static string IsCorrectProtocol(string data)
        {
            if (data != "66" && data != "67" && data != "68")
            {
                throw new ArgumentException("The protocol is not correct, values allow: 66, 67, 68");
            }

            return data;
        }

        public static string IsCorrectDate(string yymmddhhmmss)
        {
            int yy = int.Parse(yymmddhhmmss.Substring(0, 2));
            if (yy < 00 || yy > 99)
            {
                throw new ArgumentException("The part of yy is not correct, values allow: 00 to 99");
            }

            int month = int.Parse(yymmddhhmmss.Substring(2, 2));
            if (month < 0 || month > 12)
            {
                throw new ArgumentException("The part of mm is not correct, values allow: 01 to 12");
            }

            int day = int.Parse(yymmddhhmmss.Substring(4, 2));
            if(day < 0 || day > 31)
            {
                throw new ArgumentException("The part of dd is not correct, values allow: 01 to 31");
            }

            int hour = int.Parse(yymmddhhmmss.Substring(6, 2));
            if(hour < 00 || hour > 23)
            {
                throw new ArgumentException("The part of hh is not correct, values allow: 00 to 23");
            }

            int minute = int.Parse(yymmddhhmmss.Substring(8, 2));
            if(minute < 00 || minute > 59)
            {
                throw new ArgumentException("The part of mm is not correct, values allow: 00 to 59");
            }

            int second = int.Parse(yymmddhhmmss.Substring(10, 2));
            if(second < 00 || minute > 59)
            {
                throw new ArgumentException("The part of ss is not correct, values allow: 00 to 59");
            }

            return yymmddhhmmss;
        }

        public static string IsCorrectStatus(string status)
        {
            var statusInt = int.Parse(status);
            if(statusInt != 0 && statusInt != 1)
            {
                throw new ArgumentException("The status is not correct, values allow: 0 or 1");
            }

            return status;
        }

        public static string IsCorrectId(string id)
        {
            var IdInt = int.Parse(id);
            if(IdInt < 100 || IdInt > 999)
            {
                throw new ArgumentException("The Id is not correct, values allow: 100 to 999");
            }

            return id;
        }




    }



}