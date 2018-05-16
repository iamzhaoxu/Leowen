using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Leowen.Core.ErrorHandling
{
    public interface IAppException
    {
        object[] Parameters { get; }
        HttpStatusCode? HttpStatusCode { get; set; }
        int EventId { get; }
        string ReplyMessage { get; }
    }
}
