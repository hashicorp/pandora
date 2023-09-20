// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnrollmentTroubleshootingEventFailureCategoryConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Authentication")]
    @authentication,

    [Description("Authorization")]
    @authorization,

    [Description("AccountValidation")]
    @accountValidation,

    [Description("UserValidation")]
    @userValidation,

    [Description("DeviceNotSupported")]
    @deviceNotSupported,

    [Description("InMaintenance")]
    @inMaintenance,

    [Description("BadRequest")]
    @badRequest,

    [Description("FeatureNotSupported")]
    @featureNotSupported,

    [Description("EnrollmentRestrictionsEnforced")]
    @enrollmentRestrictionsEnforced,

    [Description("ClientDisconnected")]
    @clientDisconnected,

    [Description("UserAbandonment")]
    @userAbandonment,
}
