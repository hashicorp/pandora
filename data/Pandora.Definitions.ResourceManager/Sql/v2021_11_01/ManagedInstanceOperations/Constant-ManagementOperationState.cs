// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedInstanceOperations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementOperationStateConstant
{
    [Description("CancelInProgress")]
    CancelInProgress,

    [Description("Cancelled")]
    Cancelled,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Pending")]
    Pending,

    [Description("Succeeded")]
    Succeeded,
}
