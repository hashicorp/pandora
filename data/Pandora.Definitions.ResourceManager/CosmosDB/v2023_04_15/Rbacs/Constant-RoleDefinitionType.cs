// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2023_04_15.Rbacs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleDefinitionTypeConstant
{
    [Description("BuiltInRole")]
    BuiltInRole,

    [Description("CustomRole")]
    CustomRole,
}
