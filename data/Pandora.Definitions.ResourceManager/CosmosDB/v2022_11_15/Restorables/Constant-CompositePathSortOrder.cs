// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.Restorables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CompositePathSortOrderConstant
{
    [Description("ascending")]
    Ascending,

    [Description("descending")]
    Descending,
}
