

using System.Text;
using System.Text.RegularExpressions;

namespace UDPServe.Handlers
{

    public class ConvertRemoveChar
    {

        public static string RemoveChar(string message)
        {
            //Convert to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(message);

            //Remove char
            bytes[0] = 0;

            //Convert to string
            string message2 = Encoding.UTF8.GetString(bytes);

            string pattern = "[><]";
            string result = Regex.Replace(message2, pattern, "");

            result = Regex.Replace(result, ";", ",");

            return result;
        }



    }



}