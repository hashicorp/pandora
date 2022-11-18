using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2021_08_08.AlertProcessingRules;

internal class AlertProcessingRulesCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(AlertProcessingRuleModel);

\t\tpublic override ResourceID? ResourceId() => new ActionRuleId();

\t\tpublic override Type? ResponseObject() => typeof(AlertProcessingRuleModel);


}
