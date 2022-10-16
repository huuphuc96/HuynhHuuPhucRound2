using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagement.Core.Helpers
{
    public static class CommonHelper
    {
        private static Random random = new Random();
        public static string NewGuid()
        {
            var guid = Guid.NewGuid().ToString("N");
            return guid;
        }

        public static object GetPropValue<T>(string propName)
        {
            if (string.IsNullOrEmpty(propName))
                return null;

            try
            {
                var data = typeof(T).GetField(propName);
                return data?.GetValue(null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int? ToIntNullable(this string entry)
        {
            int.TryParse(entry, out int value);
            return value;
        }

        public static string ToFullName(string firtName, string lastName, string middleName = null)
        {
            var list = new List<string> { firtName, middleName, lastName };
            return string.Join(" ", list.Where(x => !string.IsNullOrEmpty(x)).Select(s => s.Trim()));
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
