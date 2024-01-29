// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MoveOperationModeConstant
{
    [Description("Copy")]
    Copy,

    [Description("Move")]
    Move,
}
