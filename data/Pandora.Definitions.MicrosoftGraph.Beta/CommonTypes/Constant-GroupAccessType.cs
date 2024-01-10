// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupAccessTypeConstant
{
    [Description("None")]
    @none,

    [Description("Private")]
    @private,

    [Description("Secret")]
    @secret,

    [Description("Public")]
    @public,
}
