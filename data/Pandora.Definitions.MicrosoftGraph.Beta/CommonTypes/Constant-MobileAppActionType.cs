// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MobileAppActionTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("InstallCommandSent")]
    @installCommandSent,

    [Description("Installed")]
    @installed,

    [Description("Uninstalled")]
    @uninstalled,

    [Description("UserRequestedInstall")]
    @userRequestedInstall,
}
