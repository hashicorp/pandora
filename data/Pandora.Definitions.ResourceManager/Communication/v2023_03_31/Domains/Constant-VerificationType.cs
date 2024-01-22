// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Communication.v2023_03_31.Domains;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VerificationTypeConstant
{
    [Description("DKIM")]
    DKIM,

    [Description("DKIM2")]
    DKIMTwo,

    [Description("DMARC")]
    DMARC,

    [Description("Domain")]
    Domain,

    [Description("SPF")]
    SPF,
}
