// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSSoftwareUpdateStateConstant
{
    [Description("Success")]
    @success,

    [Description("Downloading")]
    @downloading,

    [Description("Downloaded")]
    @downloaded,

    [Description("Installing")]
    @installing,

    [Description("Idle")]
    @idle,

    [Description("Available")]
    @available,

    [Description("Scheduled")]
    @scheduled,

    [Description("DownloadFailed")]
    @downloadFailed,

    [Description("DownloadInsufficientSpace")]
    @downloadInsufficientSpace,

    [Description("DownloadInsufficientPower")]
    @downloadInsufficientPower,

    [Description("DownloadInsufficientNetwork")]
    @downloadInsufficientNetwork,

    [Description("InstallInsufficientSpace")]
    @installInsufficientSpace,

    [Description("InstallInsufficientPower")]
    @installInsufficientPower,

    [Description("InstallFailed")]
    @installFailed,

    [Description("CommandFailed")]
    @commandFailed,
}
