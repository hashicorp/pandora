using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations
{
    public abstract class HeadOperation : ApiOperation
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
            // shouldn't for HEAD requests so no need to support overrides
            return null;
        }

        public virtual bool LongRunning()
        {
            return false;
        }

        public HttpMethod Method()
        {
            return HttpMethod.Head;
        }

        public virtual object? OptionsObject()
        {
            // could, but generally doesn't exist for heads
            return null;
        }

        public virtual object? RequestObject()
        {
            // by default Head operations should have no request object
            return null;
        }

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }

        public object? ResponseObject()
        {
            // by default Head operations should have no response object
            return null;
        }

        public virtual string? UriSuffix()
        {
            // could be overridden but likely isn't during heads
            return null;
        }
    }
}