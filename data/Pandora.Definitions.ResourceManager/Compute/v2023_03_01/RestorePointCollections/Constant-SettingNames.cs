// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2023_03_01.RestorePointCollections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SettingNamesConstant
{
    [Description("AutoLogon")]
    AutoLogon,

    [Description("FirstLogonCommands")]
    FirstLogonCommands,
}
