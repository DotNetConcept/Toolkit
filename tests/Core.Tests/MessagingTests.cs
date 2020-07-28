using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConcept.Toolkit.Tests
{
    using DotNetConcept.Toolkit.Messaging;

    using Xunit;

    public class MessagingTests
    {
        [Fact]
        public void CreateSuccessResponse()
        {
            var headers = new Dictionary<string, object> { { "Key1", "Value1" }, { "Key2", 2 } };
            var response = Response.Success().WithCode("12345").WithHeaders(headers);
            Assert.NotNull(response);
            Assert.Null(response.Message);
            Assert.Null(response.Exception);
            Assert.Equal(ResponseStatus.Success, response.Status);
            Assert.Equal("12345", response.Code);

            Assert.NotNull(response.Headers);
            Assert.Equal("Value1", response.Headers["Key1"]);
            Assert.Equal(2, response.Headers["Key2"]);
        }

        [Fact]
        public void CreateSuccessResponseWithData()
        {
            var data = new Tuple<string, int>("TEST", 12345);
            var headers = new Dictionary<string, object> { { "Key1", "Value1" }, { "Key2", 2 } };
            var response = Response<Tuple<string, int>>.Success(data).WithCode("12345").WithHeaders(headers);
            Assert.NotNull(response);
            Assert.Null(response.Message);
            Assert.Null(response.Exception);
            Assert.Equal(ResponseStatus.Success, response.Status);
            Assert.Equal("12345", response.Code);
            Assert.Equal(data, response.Data);
        }

        [Fact]
        public void CreateErrorResponseWithMessage()
        {
            var response = Response.Error(message: "blabla").WithCode("12345");
            Assert.NotNull(response);
            Assert.Null(response.Exception);
            Assert.Equal("blabla", response.Message);
            Assert.Equal(ResponseStatus.Error, response.Status);
            Assert.Equal("12345", response.Code);
        }

        [Fact]
        public void CreateErrorResponseWithException()
        {
            var exception = new InvalidOperationException("Exception !!");
            var response = Response.Error(exception).WithCode("12345");
            Assert.NotNull(response);
            Assert.NotNull(response.Exception);
            Assert.Equal("Exception !!", response.Message);
            Assert.Equal(ResponseStatus.Error, response.Status);
            Assert.Equal("12345", response.Code);
        }

        [Fact]
        public void CreateErrorResponseWithExceptionAndMessage()
        {
            var exception = new InvalidOperationException("Exception !!");
            var response = Response.Error(exception, "blabla").WithCode("12345");
            Assert.NotNull(response);
            Assert.NotNull(response.Exception);
            Assert.Equal("blabla", response.Message);
            Assert.Equal(ResponseStatus.Error, response.Status);
            Assert.Equal("12345", response.Code);
        }

        [Fact]
        public void CreateBadRequestResponseWithMessage()
        {
            var response = Response.BadRequest("blabla");
            Assert.NotNull(response);
            Assert.Null(response.Exception);
            Assert.Equal("blabla", response.Message);
            Assert.Equal(ResponseStatus.BadRequest, response.Status);
            Assert.Null(response.Code);
        }

        [Fact]
        public void CreateNotFoundRequestResponse()
        {
            var response = Response.NotFound();
            Assert.NotNull(response);
            Assert.Null(response.Exception);
            Assert.Null(response.Message);
            Assert.Equal(ResponseStatus.NotFound, response.Status);
            Assert.Null(response.Code);
        }

        [Fact]
        public void CreateConflictRequestResponse()
        {
            var response = Response.NotFound().WithCode("789");
            Assert.NotNull(response);
            Assert.Null(response.Exception);
            Assert.Null(response.Message);
            Assert.Equal(ResponseStatus.Conflict, response.Status);
            Assert.Equal("789", response.Code);
        }
    }
}
