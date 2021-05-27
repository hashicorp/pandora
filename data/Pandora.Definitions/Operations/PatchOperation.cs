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

        public virtual object? OptionsObject()
        {
            // shouldn't be applicable for PATCHes 
            return null;
        }

        public abstract object? RequestObject();

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }
        
        public virtual object? ResponseObject()
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