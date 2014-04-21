using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shuriken.App_Start
{
    public class LogConfig
    {
        private static Dictionary<string, string> _logs = new Dictionary<string, string>();


        public static void SaveByKey(string key, string value)
        {
            if (_logs.ContainsKey(key))
                _logs[key] = value;
            else
                _logs.Add(key, value);
        }

        public static string GetByKey(string key)
        {
            return _logs[key];
        }
    }
}