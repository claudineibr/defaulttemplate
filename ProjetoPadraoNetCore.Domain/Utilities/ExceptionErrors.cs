using NascorpLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoPadraoNetCore.Domain.Utilities
{
   public class ExceptionErrors
    {
        public static ErrorResponse Extract(Exception exception, ErrorStatusCode statusCode = ErrorStatusCode.None)
        {
            string moreErrors = string.Empty;
            var errors = new List<ErrorKey>();

            if (exception.Source.Contains("Repository") && exception.InnerException != null)
            {
                if (exception.InnerException.Message.Contains("_UNIQUE"))
                {
                    string key = exception.InnerException.Message.Split(' ').LastOrDefault();
                    moreErrors = $"{key.Replace("_UNIQUE", "").Replace("'", "")} - is already registered!";
                    errors.Add(new ErrorKey() { ErrorCode = (int)ErrorStatusCode.DuplicateKey, ErrorMessage = moreErrors });
                }
                else if (exception.InnerException.Message.Contains("FOREIGN KEY"))
                {
                    string message = exception.InnerException.Message;
                    int i = message.IndexOf("(");
                    if (i >= 0) message = message.Substring(i + 1);

                    i = message.IndexOf("(");

                    if (i >= 0) message = message.Substring(i + 1);

                    i = message.IndexOf(")");

                    if (i >= 0) message = message.Substring(0, i);

                    moreErrors = $"{message.Replace("`", "")} not found";

                    errors.Add(new ErrorKey() { ErrorCode = (int)ErrorStatusCode.KeyNotFound, ErrorMessage = moreErrors });
                }
                else
                {
                    moreErrors = exception.InnerException.Message;
                    errors.Add(new ErrorKey() { ErrorCode = (int)ErrorStatusCode.Generic, ErrorMessage = moreErrors });
                }
            }
            else
            {
                errors.Add(new ErrorKey() { ErrorCode = statusCode != ErrorStatusCode.None ? (int)statusCode : (int)ErrorStatusCode.Generic, ErrorMessage = exception.Message });
            }

            return new ErrorResponse() { Errors = errors };
        }


        private class ErrorKey
        {
            public int ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
