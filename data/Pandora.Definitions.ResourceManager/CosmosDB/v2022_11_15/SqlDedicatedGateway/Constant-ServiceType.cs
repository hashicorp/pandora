// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.SqlDedicatedGateway;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceTypeConstant
{
    [Description("DataTransfer")]
    DataTransfer,

    [Description("GraphAPICompute")]
    GraphAPICompute,

    [Description("MaterializedViewsBuilder")]
    MaterializedViewsBuilder,

    [Description("SqlDedicatedGateway")]
    SqlDedicatedGateway,
}
