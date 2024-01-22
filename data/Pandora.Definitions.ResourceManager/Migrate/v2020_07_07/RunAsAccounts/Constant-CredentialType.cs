// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.RunAsAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialTypeConstant
{
    [Description("HyperVFabric")]
    HyperVFabric,

    [Description("LinuxGuest")]
    LinuxGuest,

    [Description("LinuxServer")]
    LinuxServer,

    [Description("VMwareFabric")]
    VMwareFabric,

    [Description("WindowsGuest")]
    WindowsGuest,

    [Description("WindowsServer")]
    WindowsServer,
}
