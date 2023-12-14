// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceCertificateStateCertificateRevokeStatusConstant
{
    [Description("None")]
    @none,

    [Description("Pending")]
    @pending,

    [Description("Issued")]
    @issued,

    [Description("Failed")]
    @failed,

    [Description("Revoked")]
    @revoked,
}
