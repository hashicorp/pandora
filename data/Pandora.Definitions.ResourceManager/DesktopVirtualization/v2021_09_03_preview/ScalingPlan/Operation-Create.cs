using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.ScalingPlan;

internal class CreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(ScalingPlanModel);

\t\tpublic override ResourceID? ResourceId() => new ScalingPlanId();

\t\tpublic override Type? ResponseObject() => typeof(ScalingPlanModel);


}
