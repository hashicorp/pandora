// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.RecoveryPoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RecoveryPointCompletionStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Partial")]
    Partial,
}
