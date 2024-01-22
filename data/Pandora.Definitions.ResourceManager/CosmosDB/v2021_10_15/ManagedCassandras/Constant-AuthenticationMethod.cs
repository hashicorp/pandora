// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2021_10_15.ManagedCassandras;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthenticationMethodConstant
{
    [Description("Cassandra")]
    Cassandra,

    [Description("None")]
    None,
}
