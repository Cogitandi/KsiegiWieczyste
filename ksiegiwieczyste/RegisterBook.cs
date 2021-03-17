using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ksiegiwieczyste
{
    class RegisterBook
    {
        String CourtCode;
        String ControlDigit;

        public RegisterBook(string courtCode, string controlDigit)
        {
            CourtCode = courtCode;
            ControlDigit = controlDigit;
        }
    }
}
