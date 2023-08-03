// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerEnrollmentModeConstant
{
    [Description("CorporateOwnedDedicatedDevice")]
    @corporateOwnedDedicatedDevice,

    [Description("CorporateOwnedFullyManaged")]
    @corporateOwnedFullyManaged,

    [Description("CorporateOwnedWorkProfile")]
    @corporateOwnedWorkProfile,

    [Description("CorporateOwnedAOSPUserlessDevice")]
    @corporateOwnedAOSPUserlessDevice,

    [Description("CorporateOwnedAOSPUserAssociatedDevice")]
    @corporateOwnedAOSPUserAssociatedDevice,
}
