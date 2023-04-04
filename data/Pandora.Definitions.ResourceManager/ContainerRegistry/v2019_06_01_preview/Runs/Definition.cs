using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Runs;

internal class Definition : ResourceDefinition
{
    public string Name => "Runs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new GetOperation(),
        new GetLogSasUrlOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ArchitectureConstant),
        typeof(OSConstant),
        typeof(ProvisioningStateConstant),
        typeof(RunStatusConstant),
        typeof(RunTypeConstant),
        typeof(VariantConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgentPropertiesModel),
        typeof(ImageDescriptorModel),
        typeof(ImageUpdateTriggerModel),
        typeof(PlatformPropertiesModel),
        typeof(RunModel),
        typeof(RunGetLogResultModel),
        typeof(RunPropertiesModel),
        typeof(RunUpdateParametersModel),
        typeof(SourceTriggerDescriptorModel),
        typeof(TimerTriggerDescriptorModel),
    };
}
