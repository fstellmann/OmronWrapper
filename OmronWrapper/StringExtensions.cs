using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace OmronWrapper
{
    public static class StringExtensions
    {
        public static SecureString ToSecureString(this string clearString)
        {
            SecureString secureString = new SecureString();
            clearString.ToList().ForEach(secureString.AppendChar);
            secureString.MakeReadOnly();
            return secureString;
        }
    }
}
