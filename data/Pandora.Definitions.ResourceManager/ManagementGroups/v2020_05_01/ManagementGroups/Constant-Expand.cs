// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01.ManagementGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpandConstant
{
    [Description("children")]
    Children,

    [Description("path")]
    Path,
}
