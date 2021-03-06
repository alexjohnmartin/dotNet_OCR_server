﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Ocr_Server.HttpExtentions
{
    public static class HttpRequestExtensions
    {
        public static HttpResponseMessage<T> CreateResponse<T>(this HttpRequestMessage request, T value, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            // NOTE: You'll need access to the configuration.
            var negotiator = GlobalConfiguration.Configuration.Services.GetContentNegotiator();
            var result = negotiator.Negotiate(typeof(T), request, GlobalConfiguration.Configuration.Formatters);

            // if the request shuld return an individual entity (none collection) but encountering NULL throw resource not found exception
            if (value == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return new HttpResponseMessage<T>(value, statusCode, result.Formatter);
        }

        public static HttpResponseMessage<T> CreateErrorResponse<T>(this HttpRequestMessage request, string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return CreateErrorResponse<T>(request, new Exception(message), statusCode);
        }

        public static HttpResponseMessage<T> CreateErrorResponse<T>(this HttpRequestMessage request, Exception exception, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {

            HttpConfiguration configuration1 = request.GetConfiguration();
            HttpError error = new HttpError(exception, true);
            var negotiator = GlobalConfiguration.Configuration.Services.GetContentNegotiator();
            var result = negotiator.Negotiate(typeof(T), request, GlobalConfiguration.Configuration.Formatters);
            return new HttpResponseMessage<T>(error, statusCode, result.Formatter);
        }
    }
}