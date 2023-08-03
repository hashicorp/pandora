// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TlpLevelConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("White")]
    @white,

    [Description("Green")]
    @green,

    [Description("Amber")]
    @amber,

    [Description("Red")]
    @red,
}
