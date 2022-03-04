using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.IotConnectors;

internal class FhirDestinationsListByIotConnectorOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new IotConnectorId();

    public override Type NestedItemType() => typeof(IotFhirDestinationModel);

    public override string? UriSuffix() => "/fhirDestinations";


}
