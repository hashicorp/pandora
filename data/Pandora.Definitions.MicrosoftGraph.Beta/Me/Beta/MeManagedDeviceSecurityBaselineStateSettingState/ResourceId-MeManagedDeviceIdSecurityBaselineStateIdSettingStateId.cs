// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceSecurityBaselineStateSettingState;

internal class MeManagedDeviceIdSecurityBaselineStateIdSettingStateId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/managedDevices/{managedDeviceId}/securityBaselineStates/{securityBaselineStateId}/settingStates/{securityBaselineSettingStateId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticManagedDevices", "managedDevices"),
        ResourceIDSegment.UserSpecified("managedDeviceId"),
        ResourceIDSegment.Static("staticSecurityBaselineStates", "securityBaselineStates"),
        ResourceIDSegment.UserSpecified("securityBaselineStateId"),
        ResourceIDSegment.Static("staticSettingStates", "settingStates"),
        ResourceIDSegment.UserSpecified("securityBaselineSettingStateId")
    };
}
