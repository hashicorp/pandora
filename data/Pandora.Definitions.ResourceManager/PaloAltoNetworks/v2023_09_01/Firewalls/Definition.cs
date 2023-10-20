using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.Firewalls;

internal class Definition : ResourceDefinition
{
    public string Name => "Firewalls";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AveLogProfileOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetGlobalRulestackOperation(),
        new GetLogProfileOperation(),
        new GetSupportInfoOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BillingCycleConstant),
        typeof(BooleanEnumConstant),
        typeof(DNSProxyConstant),
        typeof(EgressNatConstant),
        typeof(EnabledDNSTypeConstant),
        typeof(LogOptionConstant),
        typeof(LogTypeConstant),
        typeof(MarketplaceSubscriptionStatusConstant),
        typeof(NetworkTypeConstant),
        typeof(ProtocolTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(UsageTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicationInsightsModel),
        typeof(DNSSettingsModel),
        typeof(EndpointConfigurationModel),
        typeof(EventHubModel),
        typeof(FirewallDeploymentPropertiesModel),
        typeof(FirewallResourceModel),
        typeof(FirewallResourceUpdateModel),
        typeof(FirewallResourceUpdatePropertiesModel),
        typeof(FrontendSettingModel),
        typeof(GlobalRulestackInfoModel),
        typeof(IPAddressModel),
        typeof(IPAddressSpaceModel),
        typeof(LogDestinationModel),
        typeof(LogSettingsModel),
        typeof(MarketplaceDetailsModel),
        typeof(MonitorLogModel),
        typeof(NetworkProfileModel),
        typeof(PanoramaConfigModel),
        typeof(PlanDataModel),
        typeof(RulestackDetailsModel),
        typeof(StorageAccountModel),
        typeof(SupportInfoModel),
        typeof(VnetConfigurationModel),
        typeof(VwanConfigurationModel),
    };
}
