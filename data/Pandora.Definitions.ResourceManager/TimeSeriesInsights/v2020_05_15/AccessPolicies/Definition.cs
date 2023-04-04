using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.AccessPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "AccessPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByEnvironmentOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessPolicyRoleConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessPolicyCreateOrUpdateParametersModel),
        typeof(AccessPolicyListResponseModel),
        typeof(AccessPolicyMutablePropertiesModel),
        typeof(AccessPolicyResourceModel),
        typeof(AccessPolicyResourcePropertiesModel),
        typeof(AccessPolicyUpdateParametersModel),
    };
}
