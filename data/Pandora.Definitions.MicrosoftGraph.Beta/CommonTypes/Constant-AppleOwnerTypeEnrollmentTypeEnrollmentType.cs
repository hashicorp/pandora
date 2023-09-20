// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AppleOwnerTypeEnrollmentTypeEnrollmentTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Device")]
    @device,

    [Description("User")]
    @user,

    [Description("AccountDrivenUserEnrollment")]
    @accountDrivenUserEnrollment,

    [Description("WebDeviceEnrollment")]
    @webDeviceEnrollment,
}
