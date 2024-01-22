// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2023_04_01.ConfigurationAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TagOperatorsConstant
{
    [Description("All")]
    All,

    [Description("Any")]
    Any,
}
