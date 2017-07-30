using System;
using System.Collections.Generic;
using System.Text;

namespace Aktywator
{
    static class Common
    {
        public static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        public static string bezOgonkow(string text)
        {
            return Encoding.ASCII.GetString(Encoding.GetEncoding(1251).GetBytes(text));
        }
    }
}
