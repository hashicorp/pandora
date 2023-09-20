// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionBitlockerRecoveryKey;

internal class UserIdInformationProtectionBitlockerRecoveryKeyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/informationProtection/bitlocker/recoveryKeys/{bitlockerRecoveryKeyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticBitlocker", "bitlocker"),
        ResourceIDSegment.Static("staticRecoveryKeys", "recoveryKeys"),
        ResourceIDSegment.UserSpecified("bitlockerRecoveryKeyId")
    };
}
