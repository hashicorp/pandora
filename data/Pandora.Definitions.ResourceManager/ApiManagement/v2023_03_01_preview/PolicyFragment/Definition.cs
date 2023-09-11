using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.PolicyFragment;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyFragment";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new ListReferencesOperation(),
        new WorkspacePolicyFragmentCreateOrUpdateOperation(),
        new WorkspacePolicyFragmentDeleteOperation(),
        new WorkspacePolicyFragmentGetOperation(),
        new WorkspacePolicyFragmentGetEntityTagOperation(),
        new WorkspacePolicyFragmentListByServiceOperation(),
        new WorkspacePolicyFragmentListReferencesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PolicyFragmentContentFormatConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PolicyFragmentContractModel),
        typeof(PolicyFragmentContractPropertiesModel),
        typeof(ResourceModel),
        typeof(ResourceCollectionModel),
    };
}
