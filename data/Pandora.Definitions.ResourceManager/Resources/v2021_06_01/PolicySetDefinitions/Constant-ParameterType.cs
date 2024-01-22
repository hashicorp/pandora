// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01.PolicySetDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ParameterTypeConstant
{
    [Description("Array")]
    Array,

    [Description("Boolean")]
    Boolean,

    [Description("DateTime")]
    DateTime,

    [Description("Float")]
    Float,

    [Description("Integer")]
    Integer,

    [Description("Object")]
    Object,

    [Description("String")]
    String,
}
