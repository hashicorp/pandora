using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.Resource;

internal class ServicesCreateOrUpdateOperation : Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(ServicesDescriptionModel);

    public override ResourceID? ResourceId() => new ServiceId();

    public override Type? ResponseObject() => typeof(ServicesDescriptionModel);


}
