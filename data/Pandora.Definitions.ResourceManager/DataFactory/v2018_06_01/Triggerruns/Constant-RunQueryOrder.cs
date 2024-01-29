// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggerruns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunQueryOrderConstant
{
    [Description("ASC")]
    ASC,

    [Description("DESC")]
    DESC,
}
