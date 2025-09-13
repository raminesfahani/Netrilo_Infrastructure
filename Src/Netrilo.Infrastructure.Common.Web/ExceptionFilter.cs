using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using Netrilo.Infrastructure.Common.Abstractions.Dto;
using Netrilo.Infrastructure.Common.Abstractions.Exceptions;

namespace Netrilo.Infrastructure.Common.Web
{
    public class ExceptionFilter(
        IWebHostEnvironment env,
        ILogger<ExceptionFilter> logger) : Attribute, IExceptionFilter
    {
        protected virtual HttpStatusCode MapStatusCode(Exception ex) =>

            // Status Codes
            ex switch
            {
                ArgumentException or NotFoundException => HttpStatusCode.NotFound,
                ArgumentNullException or FluentValidation.ValidationException or ValidationException => HttpStatusCode.BadRequest,
                UnauthorizedAccessException => HttpStatusCode.Unauthorized,
                CustomApplicationException custom => custom.StatusCode,
                _ => HttpStatusCode.InternalServerError,
            };

        protected virtual IEnumerable<string> MapErrors(Exception ex) =>

            // Status Codes
            ex switch
            {
                CustomApplicationException custom => custom.Errors,
                ValidationException validation => validation.Errors,
                _ => [],
            };

        private readonly IWebHostEnvironment _env = env;
        private readonly ILogger _logger = logger;

        public virtual void OnException(ExceptionContext context)
        {
            if (context.Exception is not null)
            {
                var traceId = context.HttpContext.TraceIdentifier;
                var statusCode = (int)MapStatusCode(context.Exception);
                var errors = MapErrors(context.Exception);

                if (_env.IsProduction())
                {
                    var response = new BaseExceptionResponse(context.Exception.Message, traceId, statusCode, errors);
                    context.Result = new ObjectResult(response);
                }
                else
                {
                    var response = new BaseDevelpmentExceptionResponse(context.Exception.Message, traceId, statusCode, context.Exception, errors);
                    context.Result = new ObjectResult(response);
                }

                LogError(context, statusCode);

                context.HttpContext.Response.StatusCode = statusCode;
                context.Exception = null;
            }
        }

        protected virtual void LogError(ExceptionContext context, int statusCode)
        {
            var logTitle = $"{context.HttpContext.Request.Path} :: [{statusCode}] {context.Exception.Message}";
            var logError = new
            {
                Context = context,
            };

            switch (statusCode)
            {
                case >= 500:
                    _logger.LogCritical(logTitle, logError);
                    break;
                case 401:
                    _logger.LogInformation(logTitle, logError);
                    break;
                default:
                    _logger.LogWarning(logTitle, logError);
                    break;
            }
        }
    }
}
