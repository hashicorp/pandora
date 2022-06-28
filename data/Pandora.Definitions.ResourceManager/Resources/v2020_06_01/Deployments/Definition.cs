using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Deployments;

internal class Definition : ResourceDefinition
{
    public string Name => "Deployments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CalculateTemplateHashOperation(),
        new CancelOperation(),
        new CancelAtManagementGroupScopeOperation(),
        new CancelAtScopeOperation(),
        new CancelAtSubscriptionScopeOperation(),
        new CancelAtTenantScopeOperation(),
        new CheckExistenceOperation(),
        new CheckExistenceAtManagementGroupScopeOperation(),
        new CheckExistenceAtScopeOperation(),
        new CheckExistenceAtSubscriptionScopeOperation(),
        new CheckExistenceAtTenantScopeOperation(),
        new CreateOrUpdateOperation(),
        new CreateOrUpdateAtManagementGroupScopeOperation(),
        new CreateOrUpdateAtScopeOperation(),
        new CreateOrUpdateAtSubscriptionScopeOperation(),
        new CreateOrUpdateAtTenantScopeOperation(),
        new DeleteOperation(),
        new DeleteAtManagementGroupScopeOperation(),
        new DeleteAtScopeOperation(),
        new DeleteAtSubscriptionScopeOperation(),
        new DeleteAtTenantScopeOperation(),
        new ExportTemplateOperation(),
        new ExportTemplateAtManagementGroupScopeOperation(),
        new ExportTemplateAtScopeOperation(),
        new ExportTemplateAtSubscriptionScopeOperation(),
        new ExportTemplateAtTenantScopeOperation(),
        new GetOperation(),
        new GetAtManagementGroupScopeOperation(),
        new GetAtScopeOperation(),
        new GetAtSubscriptionScopeOperation(),
        new GetAtTenantScopeOperation(),
        new ListAtManagementGroupScopeOperation(),
        new ListAtScopeOperation(),
        new ListAtSubscriptionScopeOperation(),
        new ListAtTenantScopeOperation(),
        new ListByResourceGroupOperation(),
        new ValidateOperation(),
        new ValidateAtManagementGroupScopeOperation(),
        new ValidateAtScopeOperation(),
        new ValidateAtSubscriptionScopeOperation(),
        new ValidateAtTenantScopeOperation(),
        new WhatIfOperation(),
        new WhatIfAtManagementGroupScopeOperation(),
        new WhatIfAtSubscriptionScopeOperation(),
        new WhatIfAtTenantScopeOperation(),
    };
}
