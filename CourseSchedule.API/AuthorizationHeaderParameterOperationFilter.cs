﻿using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CourseSchedule.API
{
    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                    operation.Parameters = new List<OpenApiParameter>();

                //operation.Parameters.Add(new OpenApiParameter
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Description = "access token",
                //    Required = true,
                //    Schema = new OpenApiSchema
                //    {
                //        Type = "string",
                //        Default = new OpenApiString("Bearer ")
                //    }
                //});

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "X-INSTITUTION-ID",
                    In = ParameterLocation.Header,
                    Required = true
                });
            }
        }
    }
}
