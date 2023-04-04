using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNSResolver.v2022_07_01.ForwardingRules;

internal class Definition : ResourceDefinition
{
    public string Name => "ForwardingRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ForwardingRuleStateConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ForwardingRuleModel),
        typeof(ForwardingRulePatchModel),
        typeof(ForwardingRulePatchPropertiesModel),
        typeof(ForwardingRulePropertiesModel),
        typeof(TargetDnsServerModel),
    };
}
