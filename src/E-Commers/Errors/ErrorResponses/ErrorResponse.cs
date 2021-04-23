﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace E_Commers.Errors.ErrorResponses
{
    public abstract class ErrorResponse : IErrorResponse
    {
        public string Error { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string RequestId { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(string title)
        {
            Error = title;
        }

        public virtual ObjectResult GetResult()
        {
            var res = new ObjectResult(this);
            res.StatusCode = (int?)HttpStatusCode.InternalServerError;
            return res;
        }

        public virtual IErrorResponse FillFromException(Exception ex)
        {
            return this;
        }
    }
}
