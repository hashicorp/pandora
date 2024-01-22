// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ManagedInstanceAdministrators;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedInstanceAdministratorTypeConstant
{
    [Description("ActiveDirectory")]
    ActiveDirectory,
}
