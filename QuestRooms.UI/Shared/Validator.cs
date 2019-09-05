using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestRooms.UI.Shared
{
    using System.Text.RegularExpressions;

    enum PasswordError {
        Length,
        Whitespace,
        Upper,
        Lover,
        SpecificSymbol,
        OK
    }

    public static class Validator
    {

        static Regex ValidEmailRegex = CreateValidEmailRegex();

        /// <summary>
        /// Taken from http://haacked.com/archive/2007/08/21/i-knew-how-to-validate-an-email-address-until-i.aspx
        /// </summary>
        /// <returns></returns>
        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            bool isValid = ValidEmailRegex.IsMatch(emailAddress);

            return isValid;
        }

        internal static bool PasswordIsValid(string pass, out PasswordError err)
        {
            //min 6 chars, max 12 chars
            if (pass.Length < 6 || pass.Length > 12)
            {
                err = PasswordError.Length;
                return false;
            }

            //No white space
            if (pass.Contains(" "))
            {
                err = PasswordError.Whitespace;
                return false;
            }
            //At least 1 upper case letter
            if (!pass.Any(char.IsUpper))
            {
                err = PasswordError.Upper;
                return false;
            }

            //At least 1 lower case letter
            if (!pass.Any(char.IsLower))
            {
                err = PasswordError.Lover;
                return false;
            }

            //At least 1 special char
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();
            foreach (char c in specialCharactersArray)
            {
                if (pass.Contains(c))
                {
                    err = PasswordError.OK;
                    return true;
                }
            }

            err = PasswordError.SpecificSymbol;
            return false;
        }
    }
}