using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SapLandscapeMonitor;

internal class Definition : ResourceDefinition
{
    public string Name => "SapLandscapeMonitor";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SapLandscapeMonitorProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SapLandscapeMonitorModel),
        typeof(SapLandscapeMonitorListResultModel),
        typeof(SapLandscapeMonitorMetricThresholdsModel),
        typeof(SapLandscapeMonitorPropertiesModel),
        typeof(SapLandscapeMonitorPropertiesGroupingModel),
        typeof(SapLandscapeMonitorSidMappingModel),
    };
}
