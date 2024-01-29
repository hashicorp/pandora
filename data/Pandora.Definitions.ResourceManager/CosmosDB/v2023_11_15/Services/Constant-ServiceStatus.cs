// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_11_15.Services;

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
