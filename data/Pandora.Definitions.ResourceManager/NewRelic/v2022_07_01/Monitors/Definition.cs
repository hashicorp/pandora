using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01.Monitors;

internal class Definition : ResourceDefinition
{
    public string Name => "Monitors";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetMetricRulesOperation(),
        new GetMetricStatusOperation(),
        new ListAppServicesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListHostsOperation(),
        new ListMonitoredResourcesOperation(),
        new SwitchBillingOperation(),
        new UpdateOperation(),
        new VMHostPayloadOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccountCreationSourceConstant),
        typeof(BillingCycleConstant),
        typeof(LiftrResourceCategoriesConstant),
        typeof(MarketplaceSubscriptionStatusConstant),
        typeof(MonitoringStatusConstant),
        typeof(OrgCreationSourceConstant),
        typeof(ProvisioningStateConstant),
        typeof(SendMetricsStatusConstant),
        typeof(SendingLogsStatusConstant),
        typeof(SendingMetricsStatusConstant),
        typeof(SingleSignOnStatesConstant),
        typeof(TagActionConstant),
        typeof(UsageTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountInfoModel),
        typeof(AppServiceInfoModel),
        typeof(AppServicesGetRequestModel),
        typeof(FilteringTagModel),
        typeof(HostsGetRequestModel),
        typeof(MetricRulesModel),
        typeof(MetricsRequestModel),
        typeof(MetricsStatusRequestModel),
        typeof(MetricsStatusResponseModel),
        typeof(MonitorPropertiesModel),
        typeof(MonitoredResourceModel),
        typeof(NewRelicAccountPropertiesModel),
        typeof(NewRelicMonitorResourceModel),
        typeof(NewRelicMonitorResourceUpdateModel),
        typeof(NewRelicMonitorResourceUpdatePropertiesModel),
        typeof(NewRelicSingleSignOnPropertiesModel),
        typeof(OrganizationInfoModel),
        typeof(PlanDataModel),
        typeof(SwitchBillingRequestModel),
        typeof(UserInfoModel),
        typeof(VMExtensionPayloadModel),
        typeof(VMInfoModel),
    };
}
