using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.Monitors;

internal class Definition : ResourceDefinition
{
    public string Name => "Monitors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetMarketplaceSaaSResourceDetailsOperation(),
        new GetMetricStatusOperation(),
        new GetSSODetailsOperation(),
        new GetVMHostPayloadOperation(),
        new ListAppServicesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionIdOperation(),
        new ListHostsOperation(),
        new ListLinkableEnvironmentsOperation(),
        new ListMonitoredResourcesOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AutoUpdateSettingConstant),
        typeof(AvailabilityStateConstant),
        typeof(LiftrResourceCategoriesConstant),
        typeof(LogModuleConstant),
        typeof(ManagedIdentityTypeConstant),
        typeof(MarketplaceSubscriptionStatusConstant),
        typeof(MonitoringStatusConstant),
        typeof(MonitoringTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(SSOStatusConstant),
        typeof(SendingLogsStatusConstant),
        typeof(SendingMetricsStatusConstant),
        typeof(SingleSignOnStatesConstant),
        typeof(UpdateStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountInfoModel),
        typeof(AppServiceInfoModel),
        typeof(DynatraceEnvironmentPropertiesModel),
        typeof(DynatraceSingleSignOnPropertiesModel),
        typeof(EnvironmentInfoModel),
        typeof(IdentityPropertiesModel),
        typeof(LinkableEnvironmentRequestModel),
        typeof(LinkableEnvironmentResponseModel),
        typeof(MarketplaceSaaSResourceDetailsRequestModel),
        typeof(MarketplaceSaaSResourceDetailsResponseModel),
        typeof(MetricsStatusResponseModel),
        typeof(MonitorPropertiesModel),
        typeof(MonitorResourceModel),
        typeof(MonitorResourceUpdateModel),
        typeof(MonitoredResourceModel),
        typeof(PlanDataModel),
        typeof(SSODetailsRequestModel),
        typeof(SSODetailsResponseModel),
        typeof(UserAssignedIdentityModel),
        typeof(UserInfoModel),
        typeof(VMExtensionPayloadModel),
        typeof(VMInfoModel),
    };
}
