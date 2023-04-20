using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles;

internal class Definition : ResourceDefinition
{
    public string Name => "Profiles";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckTrafficManagerRelativeDnsNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllowedEndpointRecordTypeConstant),
        typeof(EndpointMonitorStatusConstant),
        typeof(EndpointStatusConstant),
        typeof(MonitorProtocolConstant),
        typeof(ProfileMonitorStatusConstant),
        typeof(ProfileStatusConstant),
        typeof(TrafficRoutingMethodConstant),
        typeof(TrafficViewEnrollmentStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckTrafficManagerRelativeDnsNameAvailabilityParametersModel),
        typeof(DeleteOperationResultModel),
        typeof(DnsConfigModel),
        typeof(EndpointModel),
        typeof(EndpointPropertiesModel),
        typeof(EndpointPropertiesCustomHeadersInlinedModel),
        typeof(EndpointPropertiesSubnetsInlinedModel),
        typeof(MonitorConfigModel),
        typeof(MonitorConfigCustomHeadersInlinedModel),
        typeof(MonitorConfigExpectedStatusCodeRangesInlinedModel),
        typeof(ProfileModel),
        typeof(ProfileListResultModel),
        typeof(ProfilePropertiesModel),
        typeof(TrafficManagerNameAvailabilityModel),
    };
}
