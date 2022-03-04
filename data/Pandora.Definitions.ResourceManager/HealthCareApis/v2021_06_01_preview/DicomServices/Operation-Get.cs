using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.DicomServices;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new DicomServiceId();

    public override Type? ResponseObject() => typeof(DicomServiceModel);


}
