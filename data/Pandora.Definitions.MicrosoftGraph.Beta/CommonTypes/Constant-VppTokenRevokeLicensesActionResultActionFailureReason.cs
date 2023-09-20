// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VppTokenRevokeLicensesActionResultActionFailureReasonConstant
{
    [Description("None")]
    @none,

    [Description("AppleFailure")]
    @appleFailure,

    [Description("InternalError")]
    @internalError,

    [Description("ExpiredVppToken")]
    @expiredVppToken,

    [Description("ExpiredApplePushNotificationCertificate")]
    @expiredApplePushNotificationCertificate,
}
