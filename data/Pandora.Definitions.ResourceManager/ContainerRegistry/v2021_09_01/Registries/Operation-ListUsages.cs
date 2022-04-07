using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;

internal class ListUsagesOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RegistriesId();

    public override Type? ResponseObject() => typeof(RegistryUsageListResultModel);

    public override string? UriSuffix() => "/listUsages";


}
