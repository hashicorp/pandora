using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

internal class Definition : ResourceDefinition
{
    public string Name => "DataCollectionRules";
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
        typeof(KnownDataCollectionRuleProvisioningStateConstant),
        typeof(KnownDataCollectionRuleResourceKindConstant),
        typeof(KnownDataFlowStreamsConstant),
        typeof(KnownExtensionDataSourceStreamsConstant),
        typeof(KnownPerfCounterDataSourceStreamsConstant),
        typeof(KnownSyslogDataSourceFacilityNamesConstant),
        typeof(KnownSyslogDataSourceLogLevelsConstant),
        typeof(KnownSyslogDataSourceStreamsConstant),
        typeof(KnownWindowsEventLogDataSourceStreamsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureMonitorMetricsDestinationModel),
        typeof(DataCollectionRuleModel),
        typeof(DataCollectionRuleResourceModel),
        typeof(DataFlowModel),
        typeof(DataSourcesSpecModel),
        typeof(DestinationsSpecModel),
        typeof(ExtensionDataSourceModel),
        typeof(LogAnalyticsDestinationModel),
        typeof(PerfCounterDataSourceModel),
        typeof(ResourceForUpdateModel),
        typeof(SyslogDataSourceModel),
        typeof(WindowsEventLogDataSourceModel),
    };
}
