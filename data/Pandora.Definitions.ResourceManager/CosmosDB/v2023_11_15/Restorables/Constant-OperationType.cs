// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_11_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationTypeConstant
{
    [Description("Create")]
    Create,

    [Description("Delete")]
    Delete,

    [Description("Recreate")]
    Recreate,

    [Description("Replace")]
    Replace,

    [Description("SystemOperation")]
    SystemOperation,
}
