using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DANN.Service
{
    public static class CommonFunctions
    {
        public static int TryParseObjectToInt(object s)
        {
            int i;
            if (!int.TryParse(s + "", out i))
            {
                return 0;
            }
            else
            {
                return i;
            }
        }

        public static int TryParseId(string s)
        {
            int i;
            if (!int.TryParse(s, out i))
            {
                return 0;
            }
            else
            {
                return i;
            }
        }

        public static int? TryParseParentId(string s)
        {
            int i;
            if (!int.TryParse(s, out i))
            {
                return null;
            }
            else
            {
                return i;
            }
        }

    }
}
