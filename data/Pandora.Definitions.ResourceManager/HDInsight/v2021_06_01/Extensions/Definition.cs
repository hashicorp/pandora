using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HDInsight.v2021_06_01.Extensions;

internal class Definition : ResourceDefinition
{
    public string Name => "Extensions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new DisableAzureMonitorOperation(),
        new DisableMonitoringOperation(),
        new EnableAzureMonitorOperation(),
        new EnableMonitoringOperation(),
        new GetOperation(),
        new GetAzureMonitorStatusOperation(),
        new GetMonitoringStatusOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureMonitorRequestModel),
        typeof(AzureMonitorResponseModel),
        typeof(AzureMonitorSelectedConfigurationsModel),
        typeof(AzureMonitorTableConfigurationModel),
        typeof(ClusterMonitoringRequestModel),
        typeof(ClusterMonitoringResponseModel),
        typeof(ExtensionModel),
    };
}
