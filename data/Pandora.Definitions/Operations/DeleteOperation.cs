using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations
{
    public abstract class DeleteOperation : ApiOperation
    {
        public virtual string? ContentType()
        {
            return null;
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
            return null;
        }

        public virtual bool LongRunning()
        {
            return false;
        }

        public HttpMethod Method()
        {
            return HttpMethod.Delete;
        }

        public virtual object? OptionsObject()
        {
            // could, but generally doesn't exist for deletion
            return null;
        }

        public virtual object? RequestObject()
        {
            // almost all API's don't have a request object at delete time
            return null;
        }

        public virtual ResourceID? ResourceId()
        {
            // this _should_ but doesn't have to be present
            return null;
        }

        public virtual object? ResponseObject()
        {
            // we're not interested in the response object in delete operations
            // in most cases
            return null;
        }

        public virtual string? UriSuffix()
        {
            // could be overridden but likely isn't during deletion
            return null;
        }
    }
}