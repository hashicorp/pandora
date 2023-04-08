using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.JitNetworkAccessPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "JitNetworkAccessPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new InitiateOperation(),
        new ListOperation(),
        new ListByRegionOperation(),
        new ListByResourceGroupOperation(),
        new ListByResourceGroupAndRegionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionTypeConstant),
        typeof(ProtocolConstant),
        typeof(StatusConstant),
        typeof(StatusReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(JitNetworkAccessPolicyModel),
        typeof(JitNetworkAccessPolicyInitiatePortModel),
        typeof(JitNetworkAccessPolicyInitiateRequestModel),
        typeof(JitNetworkAccessPolicyInitiateVirtualMachineModel),
        typeof(JitNetworkAccessPolicyPropertiesModel),
        typeof(JitNetworkAccessPolicyVirtualMachineModel),
        typeof(JitNetworkAccessPortRuleModel),
        typeof(JitNetworkAccessRequestModel),
        typeof(JitNetworkAccessRequestPortModel),
        typeof(JitNetworkAccessRequestVirtualMachineModel),
    };
}
