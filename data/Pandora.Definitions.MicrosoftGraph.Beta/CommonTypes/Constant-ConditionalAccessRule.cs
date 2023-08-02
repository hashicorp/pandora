// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalAccessRuleConstant
{
    [Description("AllApps")]
    @allApps,

    [Description("FirstPartyApps")]
    @firstPartyApps,

    [Description("Office365")]
    @office365,

    [Description("AppId")]
    @appId,

    [Description("Acr")]
    @acr,

    [Description("AppFilter")]
    @appFilter,

    [Description("AllUsers")]
    @allUsers,

    [Description("Guest")]
    @guest,

    [Description("GroupId")]
    @groupId,

    [Description("RoleId")]
    @roleId,

    [Description("UserId")]
    @userId,

    [Description("AllDevicePlatforms")]
    @allDevicePlatforms,

    [Description("DevicePlatform")]
    @devicePlatform,

    [Description("AllLocations")]
    @allLocations,

    [Description("InsideCorpnet")]
    @insideCorpnet,

    [Description("AllTrustedLocations")]
    @allTrustedLocations,

    [Description("LocationId")]
    @locationId,

    [Description("AllDevices")]
    @allDevices,

    [Description("DeviceFilter")]
    @deviceFilter,

    [Description("DeviceState")]
    @deviceState,

    [Description("DeviceFilterIncludeRuleNotMatched")]
    @deviceFilterIncludeRuleNotMatched,

    [Description("AllDeviceStates")]
    @allDeviceStates,

    [Description("AnonymizedIPAddress")]
    @anonymizedIPAddress,

    [Description("UnfamiliarFeatures")]
    @unfamiliarFeatures,

    [Description("NationStateIPAddress")]
    @nationStateIPAddress,

    [Description("RealTimeThreatIntelligence")]
    @realTimeThreatIntelligence,

    [Description("InternalGuest")]
    @internalGuest,

    [Description("B2bCollaborationGuest")]
    @b2bCollaborationGuest,

    [Description("B2bCollaborationMember")]
    @b2bCollaborationMember,

    [Description("B2bDirectConnectUser")]
    @b2bDirectConnectUser,

    [Description("OtherExternalUser")]
    @otherExternalUser,

    [Description("ServiceProvider")]
    @serviceProvider,

    [Description("MicrosoftAdminPortals")]
    @microsoftAdminPortals,
}
