// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCoreControlPlanes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum InstallationStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("Installed")]
    Installed,

    [Description("Installing")]
    Installing,

    [Description("Reinstalling")]
    Reinstalling,

    [Description("RollingBack")]
    RollingBack,

    [Description("Uninstalled")]
    Uninstalled,

    [Description("Uninstalling")]
    Uninstalling,

    [Description("Updating")]
    Updating,

    [Description("Upgrading")]
    Upgrading,
}
