using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.BlobInventoryPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "BlobInventoryPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FormatConstant),
        typeof(InventoryRuleTypeConstant),
        typeof(ObjectTypeConstant),
        typeof(ScheduleConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlobInventoryPolicyModel),
        typeof(BlobInventoryPolicyDefinitionModel),
        typeof(BlobInventoryPolicyFilterModel),
        typeof(BlobInventoryPolicyPropertiesModel),
        typeof(BlobInventoryPolicyRuleModel),
        typeof(BlobInventoryPolicySchemaModel),
        typeof(ListBlobInventoryPolicyModel),
    };
}
