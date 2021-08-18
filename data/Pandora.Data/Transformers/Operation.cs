using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Pandora.Data.Helpers;
using Pandora.Data.Models;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Data.Transformers
{
    public static class Operation
    {
        public static OperationDefinition Map(ApiOperation input, string apiVersion, string apiName)
        {
            try
            {
                var statusCodes = input.ExpectedStatusCodes().Select(sc => (int)sc).ToList();
                if (statusCodes.Count == 0)
                {
                    throw new NotSupportedException("a least one status code must be expected");
                }

                var method = input.Method().ToString().ToUpper();
                var supportedMethods = new List<string>
                {
                    HttpMethod.Delete.ToString().ToUpper(),
                    HttpMethod.Get.ToString().ToUpper(),
                    HttpMethod.Head.ToString().ToUpper(),
                    HttpMethod.Patch.ToString().ToUpper(),
                    HttpMethod.Post.ToString().ToUpper(),
                    HttpMethod.Put.ToString().ToUpper(),
                };
                if (!supportedMethods.Contains(method))
                {
                    throw new NotSupportedException($"HTTP Method {method} is not implemented/supported");
                }

                var longRunning = input.LongRunning();
                Models.ObjectDefinition? requestObject = null;
                if (input.RequestObject() != null)
                {
                    requestObject = ObjectDefinition.Map(input.RequestObject()!);
                }

                Models.ObjectDefinition? responseObject = null;
                if (input.ResponseObject() != null)
                {
                    responseObject = ObjectDefinition.Map(input.ResponseObject()!);
                }

                if (longRunning && responseObject != null)
                {
                    // disregard the response object since this shouldn't be useful
                    responseObject = null;
                }

                // TODO: tests covering this?
                if (!string.IsNullOrWhiteSpace(input.FieldContainingPaginationDetails()))
                {
                    // then this has to be a ListOperation
                    if (!(input is ListOperation))
                    {
                        throw new NotSupportedException($"List operations must inherit from ListOperation but {input} doesn't");
                    }

                    var nestedElementType = ((ListOperation)input).NestedItemType();
                    if (nestedElementType == null)
                    {
                        throw new NotSupportedException("List operations must return a response object from NestedItemType()");
                    }

                    responseObject = ObjectDefinition.Map(nestedElementType);
                }

                var options = Options.Map(input.OptionsObject());
                string? resourceIdName = null;
                if (input.ResourceId() != null)
                {
                    resourceIdName = input.ResourceId().GetType().Name;
                }

                // Operation Names are now suffixed with `Operation` to avoid conflicts between Models and Operations
                // with the same name - but we should trim that off
                var operationName = input.GetType().Name;
                if (operationName.EndsWith("Operation"))
                {
                    operationName = operationName.TrimSuffix("Operation");
                }

                return new OperationDefinition
                {
                    // note: these two shouldn't be in here but it's helpful for the terraform functions
                    // probably move this out in time
                    ApiName = apiName,
                    ApiVersion = apiVersion,

                    Name = operationName,
                    Method = method,

                    ContentType = input.ContentType(),
                    ExpectedStatusCodes = statusCodes,
                    FieldContainingPaginationDetails = input.FieldContainingPaginationDetails(),
                    LongRunning = longRunning,
                    Options = options,
                    ResourceIdName = resourceIdName,
                    UriSuffix = input.UriSuffix(),

                    RequestObject = requestObject,
                    ResponseObject = responseObject,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Mapping Operation {input.GetType().FullName}", ex);
            }
        }
    }
}