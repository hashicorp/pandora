// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2021_10_15.CosmosDB;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerOperationConstant
{
    [Description("All")]
    All,

    [Description("Create")]
    Create,

    [Description("Delete")]
    Delete,

    [Description("Replace")]
    Replace,

    [Description("Update")]
    Update,
}
