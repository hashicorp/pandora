// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCPartnerAgentInstallResultInstallStatusConstant
{
    [Description("Installed")]
    @installed,

    [Description("InstallFailed")]
    @installFailed,

    [Description("Installing")]
    @installing,

    [Description("Uninstalling")]
    @uninstalling,

    [Description("UninstallFailed")]
    @uninstallFailed,

    [Description("Licensed")]
    @licensed,
}
