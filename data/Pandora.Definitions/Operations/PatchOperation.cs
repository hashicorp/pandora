using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations
{
    public abstract class PatchOperation : ApiOperation
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
            // shouldn't be applicable for PATCHes
            return null;
        }

        public virtual bool LongRunning()
        {
            return false;
        }

        public HttpMethod Method()
        {
            return HttpMethod.Patch;
        }

        public virtual Type? OptionsObject()
        {
            // shouldn't be applicable for PATCHes 
            return null;
        }
        
        public virtual Type? RequestObject()
        {
            // Almost all GET methods return an object, but there's a handful which don't.
            // This is optional to account for those (and any Data Plane resources going forwards).
            return null;
        }

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }

        public virtual Type? ResponseObject()
        {
            // we're not interested in the response from the Patch in almost all cases
            return null;
        }

        public virtual string? UriSuffix()
        {
            // could, but shouldn't be applicable for PATCHes
            return null;
        }
    }
}