// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicaTypeConstant
{
    [Description("Primary")]
    Primary,

    [Description("ReadableSecondary")]
    ReadableSecondary,
}
