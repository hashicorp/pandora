using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{
    internal class ListOperationStatusesOperation : Operations.GetOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
            };
        }

        public override ResourceID? ResourceId()
        {
            return new OperationstatuseId();
        }

        public override object? ResponseObject()
        {
            return new OperationStatusModel();
        }


    }
}
