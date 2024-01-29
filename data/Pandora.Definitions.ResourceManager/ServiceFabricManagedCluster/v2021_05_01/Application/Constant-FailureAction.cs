// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Application;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FailureActionConstant
{
    [Description("Manual")]
    Manual,

    [Description("Rollback")]
    Rollback,
}
