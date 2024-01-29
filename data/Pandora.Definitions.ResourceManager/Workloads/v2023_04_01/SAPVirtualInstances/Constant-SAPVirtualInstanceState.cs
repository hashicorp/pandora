// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SAPVirtualInstanceStateConstant
{
    [Description("DiscoveryFailed")]
    DiscoveryFailed,

    [Description("DiscoveryInProgress")]
    DiscoveryInProgress,

    [Description("DiscoveryPending")]
    DiscoveryPending,

    [Description("InfrastructureDeploymentFailed")]
    InfrastructureDeploymentFailed,

    [Description("InfrastructureDeploymentInProgress")]
    InfrastructureDeploymentInProgress,

    [Description("InfrastructureDeploymentPending")]
    InfrastructureDeploymentPending,

    [Description("RegistrationComplete")]
    RegistrationComplete,

    [Description("SoftwareDetectionFailed")]
    SoftwareDetectionFailed,

    [Description("SoftwareDetectionInProgress")]
    SoftwareDetectionInProgress,

    [Description("SoftwareInstallationFailed")]
    SoftwareInstallationFailed,

    [Description("SoftwareInstallationInProgress")]
    SoftwareInstallationInProgress,

    [Description("SoftwareInstallationPending")]
    SoftwareInstallationPending,
}
