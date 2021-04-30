using System.Collections.Generic;
using System.Net;

namespace Contact.Manager.Core.Application
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

        public void Created()
        {
            StatusCode = HttpStatusCode.Created;
        }

        public CommandResult NotFound(string message)
        {
            Success = false;
            Message = message;
            StatusCode = HttpStatusCode.NotFound;
            return this;
        }

        public CommandResult Created(string message)
        {
            StatusCode = HttpStatusCode.Created;
            return this;
        }
    }
}