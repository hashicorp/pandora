using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.ConnectionMonitors;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectionMonitors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new QueryOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionMonitorEndpointFilterItemTypeConstant),
        typeof(ConnectionMonitorEndpointFilterTypeConstant),
        typeof(ConnectionMonitorSourceStatusConstant),
        typeof(ConnectionMonitorTestConfigurationProtocolConstant),
        typeof(ConnectionMonitorTypeConstant),
        typeof(ConnectionStateConstant),
        typeof(CoverageLevelConstant),
        typeof(DestinationPortBehaviorConstant),
        typeof(EndpointTypeConstant),
        typeof(EvaluationStateConstant),
        typeof(HTTPConfigurationMethodConstant),
        typeof(IssueTypeConstant),
        typeof(OriginConstant),
        typeof(OutputTypeConstant),
        typeof(PreferredIPVersionConstant),
        typeof(ProvisioningStateConstant),
        typeof(SeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectionMonitorModel),
        typeof(ConnectionMonitorDestinationModel),
        typeof(ConnectionMonitorEndpointModel),
        typeof(ConnectionMonitorEndpointFilterModel),
        typeof(ConnectionMonitorEndpointFilterItemModel),
        typeof(ConnectionMonitorEndpointScopeModel),
        typeof(ConnectionMonitorEndpointScopeItemModel),
        typeof(ConnectionMonitorHTTPConfigurationModel),
        typeof(ConnectionMonitorIcmpConfigurationModel),
        typeof(ConnectionMonitorListResultModel),
        typeof(ConnectionMonitorOutputModel),
        typeof(ConnectionMonitorParametersModel),
        typeof(ConnectionMonitorQueryResultModel),
        typeof(ConnectionMonitorResultModel),
        typeof(ConnectionMonitorResultPropertiesModel),
        typeof(ConnectionMonitorSourceModel),
        typeof(ConnectionMonitorSuccessThresholdModel),
        typeof(ConnectionMonitorTcpConfigurationModel),
        typeof(ConnectionMonitorTestConfigurationModel),
        typeof(ConnectionMonitorTestGroupModel),
        typeof(ConnectionMonitorWorkspaceSettingsModel),
        typeof(ConnectionStateSnapshotModel),
        typeof(ConnectivityHopModel),
        typeof(ConnectivityIssueModel),
        typeof(HTTPHeaderModel),
        typeof(HopLinkModel),
        typeof(HopLinkPropertiesModel),
        typeof(TagsObjectModel),
    };
}
