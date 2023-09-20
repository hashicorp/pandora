// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PropertyTypeConstant
{
    [Description("String")]
    @string,

    [Description("Int64")]
    @int64,

    [Description("Double")]
    @double,

    [Description("DateTime")]
    @dateTime,

    [Description("Boolean")]
    @boolean,

    [Description("StringCollection")]
    @stringCollection,

    [Description("Int64Collection")]
    @int64Collection,

    [Description("DoubleCollection")]
    @doubleCollection,

    [Description("DateTimeCollection")]
    @dateTimeCollection,
}
