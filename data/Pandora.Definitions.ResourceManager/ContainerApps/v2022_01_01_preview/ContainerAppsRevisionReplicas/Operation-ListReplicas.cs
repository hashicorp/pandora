using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisionReplicas;

internal class ListReplicasOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RevisionId();

    public override Type? ResponseObject() => typeof(ReplicaCollectionModel);

    public override string? UriSuffix() => "/replicas";


}
