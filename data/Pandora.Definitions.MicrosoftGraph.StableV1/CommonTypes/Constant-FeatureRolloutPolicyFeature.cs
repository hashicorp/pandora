// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureRolloutPolicyFeatureConstant
{
    [Description("PassthroughAuthentication")]
    @passthroughAuthentication,

    [Description("SeamlessSso")]
    @seamlessSso,

    [Description("PasswordHashSync")]
    @passwordHashSync,

    [Description("EmailAsAlternateId")]
    @emailAsAlternateId,

    [Description("CertificateBasedAuthentication")]
    @certificateBasedAuthentication,

    [Description("MultiFactorAuthentication")]
    @multiFactorAuthentication,
}
