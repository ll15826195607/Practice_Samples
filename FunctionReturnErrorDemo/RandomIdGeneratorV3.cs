using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FunctionReturnErrorDemo
{
    public class RandomIdGeneratorV3
    {
        public String Generate()
        {
            String subStrOfHostName = String.Empty;
            try
            {
                subStrOfHostName = GetLastFiledOfHostName();
            }
            catch (UnknownHostExceptioon ex)
            {
                throw new IdGenerationFailureException(ex.Message);
            }

            Int64 currentTimeMills = (Int64)(DateTime.Now - DateTime.MinValue).TotalMilliseconds;
            String randomString = GenerateRandomAlphameric(8);
            String id = String.Format("{0}-{1}-{2}", subStrOfHostName, currentTimeMills, randomString);
            return id;
        }

        private String GetLastFiledOfHostName()
        {
            String subStrOfHostName = String.Empty;
            String hostName = Dns.GetHostName();
            if (String.IsNullOrEmpty(hostName))
            {
                throw new UnknownHostExceptioon("...");
            }
            subStrOfHostName = GetLastSubStrSplittedByDot(hostName);
            return subStrOfHostName;
        }

        private String GetLastSubStrSplittedByDot(String hostName)
        {
            if (String.IsNullOrEmpty(hostName))
            {
                throw new ArgumentException("hostName Is NullOrEmpty");
            }
            String[] tokens = hostName.Split("\\.".ToCharArray());
            String subStrOfHostName = tokens[tokens.Length - 1];
            return subStrOfHostName;
        }

        protected String GenerateRandomAlphameric(Int32 length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Char[] randomChars = new Char[length];
            Int32 count = 0;
            Random random = new Random();
            while (count < length)
            {
                Int32 maxAscii = 'z';
                Int32 randomAscii = random.Next(maxAscii);
                Boolean isDigit = randomAscii >= '0' && randomAscii <= '9';
                Boolean isUppercase = randomAscii >= 'A' && randomAscii <= 'Z';
                Boolean isLowercase = randomAscii >= 'a' && randomAscii <= 'z';
                if (isDigit || isUppercase || isLowercase)
                {
                    randomChars[count] = (Char)(randomAscii);
                    ++count;
                }
            }

            return new String(randomChars);
        }
    }
}
