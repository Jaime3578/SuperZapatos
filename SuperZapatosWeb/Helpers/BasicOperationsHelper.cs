using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatosWeb.Models;

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

        public static BadResponse ValidateRequest(string parameter, int total)
        {
            BadResponse br = null;
            int n;
            bool isNumeric = int.TryParse(parameter, out n);

            if (!isNumeric)
            {
                br = (new BadResponse { error_code = 400, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(400) });
            }

            if (total <= 0)
            {
                br = (new BadResponse { error_code = 404, success = "false", error_msg = BasicOperationsHelper.GetErrorCodes(404) });
            }
            return br;
        }
    }
}