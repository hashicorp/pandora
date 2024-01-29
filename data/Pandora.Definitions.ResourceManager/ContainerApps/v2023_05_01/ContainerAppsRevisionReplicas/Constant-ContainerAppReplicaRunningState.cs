// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerAppsRevisionReplicas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerAppReplicaRunningStateConstant
{
    [Description("NotRunning")]
    NotRunning,

    [Description("Running")]
    Running,

    [Description("Unknown")]
    Unknown,
}
