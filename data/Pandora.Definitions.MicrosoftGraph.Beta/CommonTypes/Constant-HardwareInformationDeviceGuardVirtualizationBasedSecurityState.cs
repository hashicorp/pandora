// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HardwareInformationDeviceGuardVirtualizationBasedSecurityStateConstant
{
    [Description("Running")]
    @running,

    [Description("RebootRequired")]
    @rebootRequired,

    [Description("Require64BitArchitecture")]
    @require64BitArchitecture,

    [Description("NotLicensed")]
    @notLicensed,

    [Description("NotConfigured")]
    @notConfigured,

    [Description("DoesNotMeetHardwareRequirements")]
    @doesNotMeetHardwareRequirements,

    [Description("Other")]
    @other,
}
