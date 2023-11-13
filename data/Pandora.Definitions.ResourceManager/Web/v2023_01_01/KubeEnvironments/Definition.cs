using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.KubeEnvironments;

internal class Definition : ResourceDefinition
{
    public string Name => "KubeEnvironments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FrontEndServiceTypeConstant),
        typeof(KubeEnvironmentProvisioningStateConstant),
        typeof(StorageTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppLogsConfigurationModel),
        typeof(ArcConfigurationModel),
        typeof(ContainerAppsConfigurationModel),
        typeof(ExtendedLocationModel),
        typeof(FrontEndConfigurationModel),
        typeof(KubeEnvironmentModel),
        typeof(KubeEnvironmentPatchResourceModel),
        typeof(KubeEnvironmentPatchResourcePropertiesModel),
        typeof(KubeEnvironmentPropertiesModel),
        typeof(LogAnalyticsConfigurationModel),
    };
}
