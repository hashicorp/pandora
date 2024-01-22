// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.TenantConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AsyncOperationStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Started")]
    Started,

    [Description("Succeeded")]
    Succeeded,
}
