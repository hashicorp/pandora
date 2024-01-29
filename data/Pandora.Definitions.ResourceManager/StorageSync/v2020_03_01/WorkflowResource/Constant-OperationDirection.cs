// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.WorkflowResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationDirectionConstant
{
    [Description("cancel")]
    Cancel,

    [Description("do")]
    Do,

    [Description("undo")]
    Undo,
}
