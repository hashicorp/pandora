using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2023_08_01.DeploymentScripts;

internal class Definition : ResourceDefinition
{
    public string Name => "DeploymentScripts";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetLogsOperation(),
        new GetLogsDefaultOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CleanupOptionsConstant),
        typeof(ScriptProvisioningStateConstant),
        typeof(ScriptTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureCliScriptModel),
        typeof(AzureCliScriptPropertiesModel),
        typeof(AzurePowerShellScriptModel),
        typeof(AzurePowerShellScriptPropertiesModel),
        typeof(ContainerConfigurationModel),
        typeof(ContainerGroupSubnetIdModel),
        typeof(DeploymentScriptModel),
        typeof(DeploymentScriptUpdateParameterModel),
        typeof(EnvironmentVariableModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorResponseModel),
        typeof(LogPropertiesModel),
        typeof(ScriptLogModel),
        typeof(ScriptLogsListModel),
        typeof(ScriptStatusModel),
        typeof(StorageAccountConfigurationModel),
    };
}
