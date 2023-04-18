using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(DataCollectionRuleResourceModel);

    public override ResourceID? ResourceId() => new DataCollectionRuleId();

    public override Type? ResponseObject() => typeof(DataCollectionRuleResourceModel);


}
