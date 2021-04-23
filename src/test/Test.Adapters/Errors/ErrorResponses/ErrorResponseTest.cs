﻿using System.Net;
using Xunit;

namespace Test.Adapters.Errors.ErrorResponses
{
    public class ErrorManagerTest
    {
        [Fact]
        public void Should_create_empty_error()
        {
            ErrorResponseMock erm = new ErrorResponseMock();

            Assert.True(string.IsNullOrEmpty(erm.Error));
        }

        [Fact]
        public void Should_return_500_status_code()
        {
            ErrorResponseMock erm = new ErrorResponseMock();

            Assert.Equal((int)HttpStatusCode.InternalServerError, erm.GetResult().StatusCode);
        }
    }
}
