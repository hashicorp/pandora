// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementParameterValueTypeConstant
{
    [Description("String")]
    @string,

    [Description("Integer")]
    @integer,

    [Description("Boolean")]
    @boolean,

    [Description("Guid")]
    @guid,

    [Description("StringCollection")]
    @stringCollection,

    [Description("IntegerCollection")]
    @integerCollection,

    [Description("BooleanCollection")]
    @booleanCollection,

    [Description("GuidCollection")]
    @guidCollection,
}
