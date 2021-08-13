using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations
{
    public abstract class ListOperation : ApiOperation
    {
        public virtual string? ContentType()
        {
            return "application/json; charset=utf-8";
        }

        public virtual IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public virtual string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public virtual bool LongRunning()
        {
            return false;
        }

        public virtual HttpMethod Method()
        {
            // these should be Get's but ListKeys operations can be Post's..
            return HttpMethod.Get;
        }

        public abstract Type NestedItemType();

        public virtual Type? OptionsObject()
        {
            // could, but generally doesn't exist for gets
            return null;
        }

        public virtual Type? RequestObject()
        {
            // by default Get models should have no request object
            return null;
        }

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }

        public Type? ResponseObject()
        {
            // TODO: hack this in?
            return NestedItemType();
        }

        public virtual string? UriSuffix()
        {
            // could be overridden but likely isn't during gets
            return null;
        }
    }
}