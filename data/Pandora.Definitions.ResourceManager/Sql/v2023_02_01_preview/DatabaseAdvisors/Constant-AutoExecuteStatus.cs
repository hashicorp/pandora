// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseAdvisors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutoExecuteStatusConstant
{
    [Description("Default")]
    Default,

    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
