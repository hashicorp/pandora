// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerCompliancePolicyAdvancedThreatProtectionRequiredSecurityLevelConstant
{
    [Description("Unavailable")]
    @unavailable,

    [Description("Secured")]
    @secured,

    [Description("Low")]
    @low,

    [Description("Medium")]
    @medium,

    [Description("High")]
    @high,

    [Description("NotSet")]
    @notSet,
}
