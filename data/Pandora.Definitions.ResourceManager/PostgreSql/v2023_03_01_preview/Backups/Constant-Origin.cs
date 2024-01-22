// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.Backups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OriginConstant
{
    [Description("Full")]
    Full,
}
