using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace Pandora.Definitions.Interfaces
{
    public interface ApiOperation
    {
        // TODO: Custom API Version
        // for when one operation uses a different API version to the others
        
        string? ContentType();
        
        IEnumerable<HttpStatusCode> ExpectedStatusCodes();

        string? FieldContainingPaginationDetails();
        
        bool LongRunning();
        
        HttpMethod Method();

        object? RequestObject();

        object? ResponseObject();

        // OptionsObject describes the Options application to this Operation, for example filtering or sorting
        object? OptionsObject();

        ResourceID? ResourceId();

        // UriSuffix is any suffix which should be applied to the URI, for example /start - to perform mutations
        // on a given object
        string? UriSuffix();
    }
}