// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.AvailableWorkloadProfiles;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicabilityConstant
{
    [Description("Custom")]
    Custom,

    [Description("LocationDefault")]
    LocationDefault,
}
