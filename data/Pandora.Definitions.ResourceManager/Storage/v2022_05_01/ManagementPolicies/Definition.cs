using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.ManagementPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagementPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RuleTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DateAfterCreationModel),
        typeof(DateAfterModificationModel),
        typeof(ManagementPolicyModel),
        typeof(ManagementPolicyActionModel),
        typeof(ManagementPolicyBaseBlobModel),
        typeof(ManagementPolicyDefinitionModel),
        typeof(ManagementPolicyFilterModel),
        typeof(ManagementPolicyPropertiesModel),
        typeof(ManagementPolicyRuleModel),
        typeof(ManagementPolicySchemaModel),
        typeof(ManagementPolicySnapShotModel),
        typeof(ManagementPolicyVersionModel),
        typeof(TagFilterModel),
    };
}
