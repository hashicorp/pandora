// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistryKeyStateHiveConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("CurrentConfig")]
    @currentConfig,

    [Description("CurrentUser")]
    @currentUser,

    [Description("LocalMachineSam")]
    @localMachineSam,

    [Description("LocalMachineSecurity")]
    @localMachineSecurity,

    [Description("LocalMachineSoftware")]
    @localMachineSoftware,

    [Description("LocalMachineSystem")]
    @localMachineSystem,

    [Description("UsersDefault")]
    @usersDefault,
}
