// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_03_02_preview.ManagedClusterSnapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedClusterSKUNameConstant
{
    [Description("Base")]
    Base,
}
