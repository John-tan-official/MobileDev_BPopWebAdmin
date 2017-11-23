using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPopWebAdmin.ServicesHandler
{
    public class EncodeDecoder
    {
        public bool ContainsAny(params string[] needles)
        {
            for (int i = 0; i < needles.Length; i++)
            {
                if (needles.Contains("?") || needles.Contains("&") || needles.Contains(";") || needles.Contains("/") || needles.Contains(":") || needles.Contains("@") || needles.Contains("="))
                {
                    return true;
                }
            }

            return false;
        }
        public string encode(string str)
        {
            // ? & ; / : @ =
            str.Replace("?", "xxy").Replace("&", "xyx").Replace(";", "xyx")
                .Replace("/", "xyy")
                .Replace(":", "yxx")
                .Replace("@", "yxy")
                .Replace("=", "xyy");
            return null;
        }
        public string decode(string str)
        {
            // ? & ; / : @ =
            str.Replace("xxy", "?").Replace("xyx", "&").Replace("xyx", ";")
                .Replace("xyy", "/")
                .Replace("yxx", ":")
                .Replace("yxy", "@")
                .Replace("xyy", "=");
            return null;
        }
    }
}