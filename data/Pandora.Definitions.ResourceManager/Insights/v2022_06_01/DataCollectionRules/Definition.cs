using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

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
        typeof(KnownColumnDefinitionTypeConstant),
        typeof(KnownDataCollectionRuleProvisioningStateConstant),
        typeof(KnownDataCollectionRuleResourceKindConstant),
        typeof(KnownDataFlowStreamsConstant),
        typeof(KnownExtensionDataSourceStreamsConstant),
        typeof(KnownLogFileTextSettingsRecordStartTimestampFormatConstant),
        typeof(KnownLogFilesDataSourceFormatConstant),
        typeof(KnownPerfCounterDataSourceStreamsConstant),
        typeof(KnownPrometheusForwarderDataSourceStreamsConstant),
        typeof(KnownSyslogDataSourceFacilityNamesConstant),
        typeof(KnownSyslogDataSourceLogLevelsConstant),
        typeof(KnownSyslogDataSourceStreamsConstant),
        typeof(KnownWindowsEventLogDataSourceStreamsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureMonitorMetricsDestinationModel),
        typeof(ColumnDefinitionModel),
        typeof(DataCollectionRuleModel),
        typeof(DataCollectionRuleResourceModel),
        typeof(DataFlowModel),
        typeof(DataImportSourcesModel),
        typeof(DataSourcesSpecModel),
        typeof(DestinationsSpecModel),
        typeof(EventHubDataSourceModel),
        typeof(EventHubDestinationModel),
        typeof(EventHubDirectDestinationModel),
        typeof(ExtensionDataSourceModel),
        typeof(IisLogsDataSourceModel),
        typeof(LogAnalyticsDestinationModel),
        typeof(LogFileSettingsModel),
        typeof(LogFileTextSettingsModel),
        typeof(LogFilesDataSourceModel),
        typeof(MetadataModel),
        typeof(MonitoringAccountDestinationModel),
        typeof(PerfCounterDataSourceModel),
        typeof(PlatformTelemetryDataSourceModel),
        typeof(PrometheusForwarderDataSourceModel),
        typeof(ResourceForUpdateModel),
        typeof(StorageBlobDestinationModel),
        typeof(StorageTableDestinationModel),
        typeof(StreamDeclarationModel),
        typeof(SyslogDataSourceModel),
        typeof(WindowsEventLogDataSourceModel),
        typeof(WindowsFirewallLogsDataSourceModel),
    };
}
