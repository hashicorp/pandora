// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01_preview.Replicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GeoRedundantBackupConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
