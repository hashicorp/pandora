using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors;

internal class RulesEnginesListByFrontDoorOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new FrontDoorId();

    public override Type NestedItemType() => typeof(RulesEngineModel);

    public override string? UriSuffix() => "/rulesEngines";


}
