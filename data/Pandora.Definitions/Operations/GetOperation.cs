using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.Operations;

public abstract class
    GetOperation : ApiOperation
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

    public virtual Type? ResponseObject()
    {
        // Almost all GET methods return an object, but there's a handful which don't.
        // This is optional to account for those (and any Data Plane resources going forwards).
        return null;
    }

    public virtual string? UriSuffix()
    {
        // could be overridden but likely isn't during gets
        return null;
    }
}