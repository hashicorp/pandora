using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.Certificates;

internal class ListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ManagedEnvironmentId();

    public override Type NestedItemType() => typeof(CertificateModel);

    public override string? UriSuffix() => "/certificates";


}
