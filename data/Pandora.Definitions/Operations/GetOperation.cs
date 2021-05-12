using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations
{
    public abstract class GetOperation : ApiOperation
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
            // could, but generally doesn't (only for Lists)
            return null;
        }

        public virtual bool LongRunning()
        {
            return false;
        }

        public HttpMethod Method()
        {
            return HttpMethod.Get;
        }

        public virtual object? OptionsObject()
        {
            // could, but generally doesn't exist for gets
            return null;
        }

        public virtual object? RequestObject()
        {
            // by default Get models should have no request object
            return null;
        }

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }

        public abstract object? ResponseObject();

        public virtual string? UriSuffix()
        {
            // could be overridden but likely isn't during gets
            return null;
        }
    }
}