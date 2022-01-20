using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts;

internal class GetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ScopedAlertId();

    public override Type? ResponseObject() => typeof(AlertModel);


}
