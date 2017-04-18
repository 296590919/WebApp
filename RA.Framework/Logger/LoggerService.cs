using System;
using System.Net.Http;
using DataAccess;
using Common.EnumDescription;

namespace Framework.Logger
{
    public class LoggerService
    {
        private LoggerService() { }
        private static LoggerService _loggerService;

        public static LoggerService GetInstance()
        {
            return _loggerService ?? (_loggerService = new LoggerService());
        }

        public void LogErrorToDb(Exception e, int operatorID = -999)
        {
            var exp = new ServerEventLogEntity()
            {
                description = e.Message,
                thread = e.Source,
                time = DateTime.Now,
                type = e.GetType().Name,
                eventLevel = EnumBigEventType.Exception.GetDescription(),
                operatorID = operatorID
            };
            DbUtilityFactory.GetDbUtility().Add(exp);
        }

        public void LogServerEventToDb(string str,EnumServerInfoType type)
        {
            var exp = new ServerEventLogEntity()
            {
                description = str,
                eventLevel = EnumBigEventType.ServerInfo.GetDescription(),
                type = type.GetDescription(),
                time = DateTime.Now
            };
            DbUtilityFactory.GetDbUtility().Add(exp);
        }

        public void LogIoCStartEventToDb(string str)
        {
            var exp = new ServerEventLogEntity()
            {
                description = str,
                eventLevel = EnumBigEventType.ServerInfo.GetDescription(),
                type = EnumServerInfoType.IoC.GetDescription(),
                time = DateTime.Now
            };
            DbUtilityFactory.GetDbUtility().Add(exp);
        }

        public void LogRequestToDb(HttpRequestMessage r, string responseStr, int operatorID = -999)
        {
            var exp = new RequestLogEntity()
            {
                method = r.Method.Method,
                url = r.RequestUri.ToString(),
                operatorID = operatorID,
                time = DateTime.Now,
                response = responseStr
            };

            DbUtilityFactory.GetDbUtility().Add(exp);
        }
    }
}
