using System.Net;

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
