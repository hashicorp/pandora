// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_08_01.Updates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StateConstant
{
    [Description("DownloadFailed")]
    DownloadFailed,

    [Description("Downloading")]
    Downloading,

    [Description("HasPrerequisite")]
    HasPrerequisite,

    [Description("HealthCheckFailed")]
    HealthCheckFailed,

    [Description("HealthChecking")]
    HealthChecking,

    [Description("InstallationFailed")]
    InstallationFailed,

    [Description("Installed")]
    Installed,

    [Description("Installing")]
    Installing,

    [Description("Invalid")]
    Invalid,

    [Description("NotApplicableBecauseAnotherUpdateIsInProgress")]
    NotApplicableBecauseAnotherUpdateIsInProgress,

    [Description("Obsolete")]
    Obsolete,

    [Description("PreparationFailed")]
    PreparationFailed,

    [Description("Preparing")]
    Preparing,

    [Description("Ready")]
    Ready,

    [Description("ReadyToInstall")]
    ReadyToInstall,

    [Description("Recalled")]
    Recalled,

    [Description("ScanFailed")]
    ScanFailed,

    [Description("ScanInProgress")]
    ScanInProgress,
}
