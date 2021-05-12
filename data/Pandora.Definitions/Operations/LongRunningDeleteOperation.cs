using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.Operations
{
    public abstract class LongRunningDeleteOperation : DeleteOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
            };
        }
        
        public override bool LongRunning()
        {
            return true;
        }
    }
}