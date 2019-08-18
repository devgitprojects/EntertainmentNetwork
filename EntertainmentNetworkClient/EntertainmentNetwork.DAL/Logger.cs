using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Runtime.CompilerServices;

namespace EntertainmentNetwork.DAL.Logging
{
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger("EntertainmentNetworkLogger");

        public static TResult ExecuteAndLog<TResult>(Func<TResult> func,
            [CallerMemberName]string callerMemberName = null,
            [CallerFilePath]string callerFilePath = null,
            [CallerLineNumber]int callerLineNumber = 0)
        {
            try
            {
                Logger.Debug("Execution operation CallerMemberName: {0}, CallerFilePath: {1}, CallerLineNumber: {2}",
                    callerMemberName, callerFilePath, callerLineNumber);                    
                return func();
            }
            catch (Exception ex)
            {
                log.Fatal(ex);
                throw;
            }
        }

        public static void Debug(string message, params object[] args)
	    {
            log.Debug(String.Format(message, args));
	    }
    }
}
