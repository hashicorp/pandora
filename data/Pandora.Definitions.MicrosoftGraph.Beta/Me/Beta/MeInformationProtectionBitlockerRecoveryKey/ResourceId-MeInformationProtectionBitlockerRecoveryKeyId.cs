// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInformationProtectionBitlockerRecoveryKey;

internal class MeInformationProtectionBitlockerRecoveryKeyId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/informationProtection/bitlocker/recoveryKeys/{bitlockerRecoveryKeyId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticInformationProtection", "informationProtection"),
        ResourceIDSegment.Static("staticBitlocker", "bitlocker"),
        ResourceIDSegment.Static("staticRecoveryKeys", "recoveryKeys"),
        ResourceIDSegment.UserSpecified("bitlockerRecoveryKeyId")
    };
}
