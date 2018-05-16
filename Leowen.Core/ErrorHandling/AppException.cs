using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Leowen.Core.ErrorHandling
{
    public class AppException : System.Exception, IAppException
    {
        public object[] Parameters { get; }
        public int EventId { get; }
        public HttpStatusCode? HttpStatusCode { get; set; }
        public string ReplyMessage { get; }

        public AppException(EventId eventId, string errorMessage, Exception innerException = null) 
            : this(eventId, errorMessage, null, innerException)
        {
        }

        public AppException(EventId eventId, string errorMessage, string replyMessage, Exception innerException = null) : base(errorMessage, innerException)
        {
            EventId = (int)eventId;
            ReplyMessage = replyMessage;
            Parameters = new object[]{};
        }
    }
}
