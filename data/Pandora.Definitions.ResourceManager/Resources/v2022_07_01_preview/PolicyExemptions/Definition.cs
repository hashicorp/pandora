using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_07_01_preview.PolicyExemptions;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyExemptions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListForManagementGroupOperation(),
        new ListForResourceOperation(),
        new ListForResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AssignmentScopeValidationConstant),
        typeof(ExemptionCategoryConstant),
        typeof(SelectorKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PolicyExemptionModel),
        typeof(PolicyExemptionPropertiesModel),
        typeof(PolicyExemptionUpdateModel),
        typeof(PolicyExemptionUpdatePropertiesModel),
        typeof(ResourceSelectorModel),
        typeof(SelectorModel),
    };
}
