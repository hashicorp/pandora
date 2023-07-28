using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.Jobs;

internal class Definition : ResourceDefinition
{
    public string Name => "Jobs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExecutionsListOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListSecretsOperation(),
        new StartOperation(),
        new StopExecutionOperation(),
        new StopMultipleExecutionsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(JobExecutionRunningStateConstant),
        typeof(JobProvisioningStateConstant),
        typeof(SchemeConstant),
        typeof(StorageTypeConstant),
        typeof(TriggerTypeConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BaseContainerModel),
        typeof(ContainerModel),
        typeof(ContainerAppJobExecutionsModel),
        typeof(ContainerAppProbeModel),
        typeof(ContainerAppProbeHTTPGetModel),
        typeof(ContainerAppProbeHTTPGetHTTPHeadersInlinedModel),
        typeof(ContainerAppProbeTcpSocketModel),
        typeof(ContainerResourcesModel),
        typeof(EnvironmentVarModel),
        typeof(JobModel),
        typeof(JobConfigurationModel),
        typeof(JobConfigurationManualTriggerConfigModel),
        typeof(JobConfigurationScheduleTriggerConfigModel),
        typeof(JobExecutionModel),
        typeof(JobExecutionBaseModel),
        typeof(JobExecutionContainerModel),
        typeof(JobExecutionNamesCollectionModel),
        typeof(JobExecutionTemplateModel),
        typeof(JobPatchPropertiesModel),
        typeof(JobPatchPropertiesPropertiesModel),
        typeof(JobPropertiesModel),
        typeof(JobSecretsCollectionModel),
        typeof(JobTemplateModel),
        typeof(RegistryCredentialsModel),
        typeof(SecretModel),
        typeof(SecretVolumeItemModel),
        typeof(VolumeModel),
        typeof(VolumeMountModel),
    };
}
