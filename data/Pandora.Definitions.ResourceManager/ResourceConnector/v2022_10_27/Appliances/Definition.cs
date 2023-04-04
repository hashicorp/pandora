using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ResourceConnector.v2022_10_27.Appliances;

internal class Definition : ResourceDefinition
{
    public string Name => "Appliances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetTelemetryConfigOperation(),
        new GetUpgradeGraphOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListClusterUserCredentialOperation(),
        new ListKeysOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessProfileTypeConstant),
        typeof(DistroConstant),
        typeof(ProviderConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplianceModel),
        typeof(ApplianceCredentialKubeconfigModel),
        typeof(ApplianceGetTelemetryConfigResultModel),
        typeof(ApplianceListCredentialResultsModel),
        typeof(ApplianceListKeysResultsModel),
        typeof(AppliancePropertiesModel),
        typeof(AppliancePropertiesInfrastructureConfigModel),
        typeof(ArtifactProfileModel),
        typeof(HybridConnectionConfigModel),
        typeof(PatchableApplianceModel),
        typeof(SSHKeyModel),
        typeof(SupportedVersionModel),
        typeof(SupportedVersionCatalogVersionModel),
        typeof(SupportedVersionCatalogVersionDataModel),
        typeof(SupportedVersionMetadataModel),
        typeof(UpgradeGraphModel),
        typeof(UpgradeGraphPropertiesModel),
    };
}
