using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.NetworkWatchers;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkWatchers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckConnectivityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetAzureReachabilityReportOperation(),
        new GetFlowLogStatusOperation(),
        new GetNetworkConfigurationDiagnosticOperation(),
        new GetNextHopOperation(),
        new GetTopologyOperation(),
        new GetTroubleshootingOperation(),
        new GetTroubleshootingResultOperation(),
        new GetVMSecurityRulesOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAvailableProvidersOperation(),
        new SetFlowLogConfigurationOperation(),
        new UpdateTagsOperation(),
        new VerifyIPFlowOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessConstant),
        typeof(AssociationTypeConstant),
        typeof(ConnectionStatusConstant),
        typeof(DirectionConstant),
        typeof(EffectiveSecurityRuleProtocolConstant),
        typeof(FlowLogFormatTypeConstant),
        typeof(HTTPMethodConstant),
        typeof(IPFlowProtocolConstant),
        typeof(IPVersionConstant),
        typeof(IssueTypeConstant),
        typeof(NextHopTypeConstant),
        typeof(OriginConstant),
        typeof(ProtocolConstant),
        typeof(ProvisioningStateConstant),
        typeof(SecurityRuleAccessConstant),
        typeof(SecurityRuleDirectionConstant),
        typeof(SecurityRuleProtocolConstant),
        typeof(SeverityConstant),
        typeof(VerbosityLevelConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationSecurityGroupModel),
        typeof(ApplicationSecurityGroupPropertiesFormatModel),
        typeof(AvailableProvidersListModel),
        typeof(AvailableProvidersListCityModel),
        typeof(AvailableProvidersListCountryModel),
        typeof(AvailableProvidersListParametersModel),
        typeof(AvailableProvidersListStateModel),
        typeof(AzureReachabilityReportModel),
        typeof(AzureReachabilityReportItemModel),
        typeof(AzureReachabilityReportLatencyInfoModel),
        typeof(AzureReachabilityReportLocationModel),
        typeof(AzureReachabilityReportParametersModel),
        typeof(ConnectivityDestinationModel),
        typeof(ConnectivityHopModel),
        typeof(ConnectivityInformationModel),
        typeof(ConnectivityIssueModel),
        typeof(ConnectivityParametersModel),
        typeof(ConnectivitySourceModel),
        typeof(EffectiveNetworkSecurityRuleModel),
        typeof(EvaluatedNetworkSecurityGroupModel),
        typeof(FlowLogFormatParametersModel),
        typeof(FlowLogInformationModel),
        typeof(FlowLogPropertiesModel),
        typeof(FlowLogStatusParametersModel),
        typeof(HTTPConfigurationModel),
        typeof(HTTPHeaderModel),
        typeof(HopLinkModel),
        typeof(HopLinkPropertiesModel),
        typeof(MatchedRuleModel),
        typeof(NetworkConfigurationDiagnosticParametersModel),
        typeof(NetworkConfigurationDiagnosticProfileModel),
        typeof(NetworkConfigurationDiagnosticResponseModel),
        typeof(NetworkConfigurationDiagnosticResultModel),
        typeof(NetworkInterfaceAssociationModel),
        typeof(NetworkSecurityGroupResultModel),
        typeof(NetworkSecurityRulesEvaluationResultModel),
        typeof(NetworkWatcherModel),
        typeof(NetworkWatcherListResultModel),
        typeof(NetworkWatcherPropertiesFormatModel),
        typeof(NextHopParametersModel),
        typeof(NextHopResultModel),
        typeof(ProtocolConfigurationModel),
        typeof(QueryTroubleshootingParametersModel),
        typeof(RetentionPolicyParametersModel),
        typeof(SecurityGroupNetworkInterfaceModel),
        typeof(SecurityGroupViewParametersModel),
        typeof(SecurityGroupViewResultModel),
        typeof(SecurityRuleModel),
        typeof(SecurityRuleAssociationsModel),
        typeof(SecurityRulePropertiesFormatModel),
        typeof(SubResourceModel),
        typeof(SubnetAssociationModel),
        typeof(TagsObjectModel),
        typeof(TopologyModel),
        typeof(TopologyAssociationModel),
        typeof(TopologyParametersModel),
        typeof(TopologyResourceModel),
        typeof(TrafficAnalyticsConfigurationPropertiesModel),
        typeof(TrafficAnalyticsPropertiesModel),
        typeof(TroubleshootingDetailsModel),
        typeof(TroubleshootingParametersModel),
        typeof(TroubleshootingPropertiesModel),
        typeof(TroubleshootingRecommendedActionsModel),
        typeof(TroubleshootingResultModel),
        typeof(VerificationIPFlowParametersModel),
        typeof(VerificationIPFlowResultModel),
    };
}
