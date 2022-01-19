using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.Operations;

public abstract class LongRunningPostOperation : PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
    {
        return new List<HttpStatusCode>
        {
            HttpStatusCode.Accepted,
            HttpStatusCode.Created,
        };
    }

    public override bool LongRunning()
    {
        return true;
    }
}