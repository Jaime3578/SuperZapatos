using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Helpers
{
    public static class BasicOperationsHelper
    {
        public static string GetErrorCodes(int errorCode)
        {
            Dictionary<int, string> errorsCode = new Dictionary<int, string>();

            errorsCode.Add(400, "BadRequest");
            errorsCode.Add(401, "Not authorized");
            errorsCode.Add(404, "Record not found");
            errorsCode.Add(500, "Server error");

            return errorsCode[errorCode];
        }
    }
}