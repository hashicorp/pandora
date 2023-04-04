using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;

internal class Definition : ResourceDefinition
{
    public string Name => "Tasks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDetailsOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ArchitectureConstant),
        typeof(BaseImageDependencyTypeConstant),
        typeof(BaseImageTriggerTypeConstant),
        typeof(OSConstant),
        typeof(ProvisioningStateConstant),
        typeof(SecretObjectTypeConstant),
        typeof(SourceControlTypeConstant),
        typeof(SourceRegistryLoginModeConstant),
        typeof(SourceTriggerEventConstant),
        typeof(StepTypeConstant),
        typeof(TaskStatusConstant),
        typeof(TokenTypeConstant),
        typeof(TriggerStatusConstant),
        typeof(UpdateTriggerPayloadTypeConstant),
        typeof(VariantConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentPropertiesModel),
        typeof(ArgumentModel),
        typeof(AuthInfoModel),
        typeof(AuthInfoUpdateParametersModel),
        typeof(BaseImageDependencyModel),
        typeof(BaseImageTriggerModel),
        typeof(BaseImageTriggerUpdateParametersModel),
        typeof(CredentialsModel),
        typeof(CustomRegistryCredentialsModel),
        typeof(DockerBuildStepModel),
        typeof(DockerBuildStepUpdateParametersModel),
        typeof(EncodedTaskStepModel),
        typeof(EncodedTaskStepUpdateParametersModel),
        typeof(FileTaskStepModel),
        typeof(FileTaskStepUpdateParametersModel),
        typeof(PlatformPropertiesModel),
        typeof(PlatformUpdateParametersModel),
        typeof(SecretObjectModel),
        typeof(SetValueModel),
        typeof(SourcePropertiesModel),
        typeof(SourceRegistryCredentialsModel),
        typeof(SourceTriggerModel),
        typeof(SourceTriggerUpdateParametersModel),
        typeof(SourceUpdateParametersModel),
        typeof(TaskModel),
        typeof(TaskPropertiesModel),
        typeof(TaskPropertiesUpdateParametersModel),
        typeof(TaskStepPropertiesModel),
        typeof(TaskStepUpdateParametersModel),
        typeof(TaskUpdateParametersModel),
        typeof(TimerTriggerModel),
        typeof(TimerTriggerUpdateParametersModel),
        typeof(TriggerPropertiesModel),
        typeof(TriggerUpdateParametersModel),
    };
}
