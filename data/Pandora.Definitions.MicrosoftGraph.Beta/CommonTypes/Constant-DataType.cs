// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataTypeConstant
{
    [Description("None")]
    @none,

    [Description("Boolean")]
    @boolean,

    [Description("Int64")]
    @int64,

    [Description("Double")]
    @double,

    [Description("String")]
    @string,

    [Description("DateTime")]
    @dateTime,

    [Description("Version")]
    @version,

    [Description("Base64")]
    @base64,

    [Description("Xml")]
    @xml,

    [Description("BooleanArray")]
    @booleanArray,

    [Description("Int64Array")]
    @int64Array,

    [Description("DoubleArray")]
    @doubleArray,

    [Description("StringArray")]
    @stringArray,

    [Description("DateTimeArray")]
    @dateTimeArray,

    [Description("VersionArray")]
    @versionArray,
}
