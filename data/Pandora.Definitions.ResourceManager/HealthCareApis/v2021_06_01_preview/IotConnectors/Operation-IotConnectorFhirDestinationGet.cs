using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.IotConnectors;

internal class IotConnectorFhirDestinationGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new FhirDestinationId();

    public override Type? ResponseObject() => typeof(IotFhirDestinationModel);


}
