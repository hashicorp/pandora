// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_11_15.SqlDedicatedGateway;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceStatusConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Error")]
    Error,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,

    [Description("Updating")]
    Updating,
}
