using System.Web.Helpers;

namespace TrainerSpace
{
    class Functions
    {
        

        public static string GetSalt() {
            return Crypto.SHA256("TheBestSaltUHaveEverSeen");
        }


        public static bool StringOkay(string str)
        {
            string[] charsToRemove = new string[] { "@", ",", ".", ";", "'","\"",@"\","!","/","=","*","`"};
            string result = str;
            foreach (var c in charsToRemove)
            {
                result = result.Replace(c, string.Empty);
            }
            if (result.Equals(str))
            {
                return true;
            }
            else {
                return false;
            }
            
        }


        public static string Hash(string input, bool withsalt=false)
        {
            return Crypto.HashPassword(input);

        }


        public static bool IsEmpty(string str) {
            if (!str.Equals(""))
            {
                return false;
            }
            else {
                return true;
            }
        }

    }
}
