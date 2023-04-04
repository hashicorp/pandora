using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_03_01.Clusters;

internal class Definition : ResourceDefinition
{
    public string Name => "Clusters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClusterNodeTypeConstant),
        typeof(DiagnosticLevelConstant),
        typeof(ImdsAttestationConstant),
        typeof(ProvisioningStateConstant),
        typeof(SoftwareAssuranceIntentConstant),
        typeof(SoftwareAssuranceStatusConstant),
        typeof(StatusConstant),
        typeof(WindowsServerSubscriptionConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterModel),
        typeof(ClusterDesiredPropertiesModel),
        typeof(ClusterNodeModel),
        typeof(ClusterPatchModel),
        typeof(ClusterPatchPropertiesModel),
        typeof(ClusterPropertiesModel),
        typeof(ClusterReportedPropertiesModel),
        typeof(SoftwareAssurancePropertiesModel),
    };
}
