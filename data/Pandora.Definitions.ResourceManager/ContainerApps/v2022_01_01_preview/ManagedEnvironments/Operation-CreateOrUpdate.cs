using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ManagedEnvironmentModel);

    public override ResourceID? ResourceId() => new ManagedEnvironmentId();

    public override Type? ResponseObject() => typeof(ManagedEnvironmentModel);


}
