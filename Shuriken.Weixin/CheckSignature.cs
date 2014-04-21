using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shuriken.Weixin
{
    public class CheckSignature
    {
        public static readonly string DEFAULT_TOKEN = "ShurikenWX";


        public static bool IsValid(string signature, string timestamp, string nonce, string token = null)
        {
            return signature == Parse(timestamp, nonce, token);
        }

        private static string Parse(string timestamp, string nonce, string token = null)
        {
            token = token ?? DEFAULT_TOKEN;

            var sigArr = new string[] { token, timestamp, nonce }.OrderBy(z=>z);
            var sigStr = string.Join("", sigArr);

            var sha1 = System.Security.Cryptography.SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(sigStr));

            StringBuilder sigBuilder = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                sigBuilder.AppendFormat("{0:x2}", b);
            }

            _localSignature=sigBuilder.ToString();

            return _localSignature;

        }

        public static string GetLocal()
        {
            return _localSignature;
        }

        private static string _localSignature = string.Empty;

    }
}
