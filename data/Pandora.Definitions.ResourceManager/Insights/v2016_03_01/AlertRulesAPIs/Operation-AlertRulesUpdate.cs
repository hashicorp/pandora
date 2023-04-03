using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2016_03_01.AlertRulesAPIs;

internal class AlertRulesUpdateOperation : Operations.PatchOperation
{
    public override Type? RequestObject() => typeof(AlertRuleResourcePatchModel);

    public override ResourceID? ResourceId() => new AlertruleId();

    public override Type? ResponseObject() => typeof(AlertRuleResourceModel);


}
