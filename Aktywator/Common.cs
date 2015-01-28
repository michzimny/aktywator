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

        public static string bezOgonkow(string str)
        {
            str = str.Replace('ą', 'a');
            str = str.Replace('ć', 'c');
            str = str.Replace('ę', 'e');
            str = str.Replace('ł', 'l');
            str = str.Replace('ń', 'n');
            str = str.Replace('ó', 'o');
            str = str.Replace('ś', 's');
            str = str.Replace('ź', 'z');
            str = str.Replace('ż', 'z');
            str = str.Replace('Ą', 'A');
            str = str.Replace('Ć', 'C');
            str = str.Replace('Ę', 'E');
            str = str.Replace('Ł', 'L');
            str = str.Replace('Ń', 'N');
            str = str.Replace('Ó', 'O');
            str = str.Replace('Ś', 'S');
            str = str.Replace('Ź', 'Z');
            str = str.Replace('Ż', 'Z');
            return str;
        }
    }
}
