

namespace UDPServe.Handlers
{

    public class ConvertDate
    {

        public static string ConvertDateTime(string yymmddhhmmss)
        {
            int year = 2000 + int.Parse(yymmddhhmmss.Substring(0, 2));
            int month = int.Parse(yymmddhhmmss.Substring(2, 2));
            int day = int.Parse(yymmddhhmmss.Substring(4, 2));
            int hour = int.Parse(yymmddhhmmss.Substring(6, 2));
            int minute = int.Parse(yymmddhhmmss.Substring(8, 2));
            int second = int.Parse(yymmddhhmmss.Substring(10, 2));

            DateTime dateTime = new DateTime(year, month, day, hour, minute, second);
            string formattedDateTime = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

            return formattedDateTime;
        }



    }



}