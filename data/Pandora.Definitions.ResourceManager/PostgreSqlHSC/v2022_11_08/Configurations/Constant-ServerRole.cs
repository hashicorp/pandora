// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Configurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerRoleConstant
{
    [Description("Coordinator")]
    Coordinator,

    [Description("Worker")]
    Worker,
}
