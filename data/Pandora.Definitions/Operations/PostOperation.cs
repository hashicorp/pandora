using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations
{
    public abstract class PostOperation : ApiOperation
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

        public string? FieldContainingPaginationDetails()
        {
            // shouldn't be applicable for POSTs
            return null;
        }

        public virtual bool LongRunning()
        {
            return false;
        }

        public HttpMethod Method()
        {
            return HttpMethod.Post;
        }

        public virtual Type? OptionsObject()
        {
            // shouldn't be applicable for POST
            return null;
        }

        public abstract Type? RequestObject();

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }

        public virtual Type? ResponseObject()
        {
            // we're not interested in the response from the Post in almost all cases
            return null;
        }

        public virtual string? UriSuffix()
        {
            // could be a thing but isn't by default
            return null;
        }
    }
}