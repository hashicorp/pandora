using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.DataPlane.AppConfiguration.v1_0.Locks
{
    internal class DeleteLock : DeleteOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override object? ResponseObject()
        {
            return new KeyValue();
        }
    }
}
