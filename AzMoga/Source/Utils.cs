using System;
using System.Collections.Generic;
using System.Text;

namespace AzMoga
{
    static class Utils
    {
        public static bool IsUIKeyValid(ConsoleKeyInfo keyInfo)
        {
            if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key != ConsoleKey.DownArrow && keyInfo.Key != ConsoleKey.Escape)
            {
                return false;
            }

            return true;
        }
    }
}
