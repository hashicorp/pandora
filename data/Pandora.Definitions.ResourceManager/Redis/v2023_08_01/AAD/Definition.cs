using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2023_08_01.AAD;

internal class Definition : ResourceDefinition
{
    public string Name => "AAD";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AccessPolicyAssignmentCreateUpdateOperation(),
        new AccessPolicyAssignmentDeleteOperation(),
        new AccessPolicyAssignmentGetOperation(),
        new AccessPolicyAssignmentListOperation(),
        new AccessPolicyCreateUpdateOperation(),
        new AccessPolicyDeleteOperation(),
        new AccessPolicyGetOperation(),
        new AccessPolicyListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessPolicyAssignmentProvisioningStateConstant),
        typeof(AccessPolicyProvisioningStateConstant),
        typeof(AccessPolicyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RedisCacheAccessPolicyModel),
        typeof(RedisCacheAccessPolicyAssignmentModel),
        typeof(RedisCacheAccessPolicyAssignmentPropertiesModel),
        typeof(RedisCacheAccessPolicyPropertiesModel),
    };
}
