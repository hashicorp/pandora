// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComanagementEligibleDeviceClientRegistrationStatusConstant
{
    [Description("NotRegistered")]
    @notRegistered,

    [Description("Registered")]
    @registered,

    [Description("Revoked")]
    @revoked,

    [Description("KeyConflict")]
    @keyConflict,

    [Description("ApprovalPending")]
    @approvalPending,

    [Description("CertificateReset")]
    @certificateReset,

    [Description("NotRegisteredPendingEnrollment")]
    @notRegisteredPendingEnrollment,

    [Description("Unknown")]
    @unknown,
}
