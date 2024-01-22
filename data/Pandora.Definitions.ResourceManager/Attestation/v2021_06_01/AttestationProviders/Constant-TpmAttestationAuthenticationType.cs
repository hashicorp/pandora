// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Attestation.v2021_06_01.AttestationProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TpmAttestationAuthenticationTypeConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
