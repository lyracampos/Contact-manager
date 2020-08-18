using System.Collections.Generic;
using System.Net;

namespace Contact.Manager.Framework.Application
{
    public class CommandResult
    {
        public CommandResult()
        {
            Success = true;
            Message = "Operação executada com sucesso";
            StatusCode =  HttpStatusCode.OK;
        }
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public List<string> Errors { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        public CommandResult Created()
        {
            StatusCode = HttpStatusCode.Created;
            return this;
        }

        public CommandResult NotFound(string message)
        {
            Success = false;
            Message = message;
            StatusCode = HttpStatusCode.NotFound;
            return this;

        }
    }
}