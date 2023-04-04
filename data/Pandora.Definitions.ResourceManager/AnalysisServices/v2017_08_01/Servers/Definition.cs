using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;

internal class Definition : ResourceDefinition
{
    public string Name => "Servers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new DissociateGatewayOperation(),
        new GetDetailsOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListGatewayStatusOperation(),
        new ListSkusForExistingOperation(),
        new ResumeOperation(),
        new SuspendOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionModeConstant),
        typeof(ManagedModeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ServerMonitorModeConstant),
        typeof(SkuTierConstant),
        typeof(StateConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AnalysisServicesServerModel),
        typeof(AnalysisServicesServerMutablePropertiesModel),
        typeof(AnalysisServicesServerPropertiesModel),
        typeof(AnalysisServicesServerUpdateParametersModel),
        typeof(AnalysisServicesServersModel),
        typeof(CheckServerNameAvailabilityParametersModel),
        typeof(CheckServerNameAvailabilityResultModel),
        typeof(GatewayDetailsModel),
        typeof(GatewayListStatusLiveModel),
        typeof(IPv4FirewallRuleModel),
        typeof(IPv4FirewallSettingsModel),
        typeof(ResourceSkuModel),
        typeof(ServerAdministratorsModel),
        typeof(SkuDetailsForExistingResourceModel),
        typeof(SkuEnumerationForExistingResourceResultModel),
    };
}
