using System;

namespace ExceptionManager
{
    public static class ExceptionManager
    {
        public static string GetDeepestExceptionMessage(Exception exception)
        {
            var deepestException = GetDeepestException(exception);
            return Common.GetExceptionMessage(deepestException);
        }

        public static Exception GetDeepestException(Exception exception)
        {
            Exception ex = exception;
            while (ex.InnerException != null)
                ex = ex.InnerException;

            return ex;
        }

        public static string GetInnerExceptionMessage(Exception exception)
        {
            return GetInnerException(exception)?.Message;
        }

        public static Exception GetInnerException(Exception exception)
        {
            return exception.InnerException;
        }
        
        public static class Concatener
        {
            public static string ConcatAllInnerExceptionMessages(Exception exception, string separator = ",")
            {
                string messages = Common.GetExceptionMessage(exception);

                var baseException = exception;
                while (baseException.InnerException != null)
                {
                    baseException = baseException.InnerException;
                    messages += $"{separator} {Common.GetExceptionMessage(baseException)}";
                }

                exception = new Exception(messages);

                return Common.GetExceptionMessage(exception);
            }
        }

        protected static class Common
        {
            public static string GetExceptionMessage(Exception exception)
            {
                return exception?.Message;
            }
        }
    }
}
