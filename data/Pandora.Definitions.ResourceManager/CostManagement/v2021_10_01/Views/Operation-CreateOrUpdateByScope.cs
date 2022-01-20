using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Views;

internal class CreateOrUpdateByScopeOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(ViewModel);

    public override ResourceID? ResourceId() => new ScopedViewId();

    public override Type? ResponseObject() => typeof(ViewModel);


}
