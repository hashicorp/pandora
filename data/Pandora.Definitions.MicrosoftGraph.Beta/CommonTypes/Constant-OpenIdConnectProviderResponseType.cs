// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OpenIdConnectProviderResponseTypeConstant
{
    [Description("Code")]
    @code,

    [Description("Idtoken")]
    @id_token,

    [Description("Token")]
    @token,
}
