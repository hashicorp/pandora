// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationLocalSecurityOptionsSmartCardRemovalBehaviorConstant
{
    [Description("NoAction")]
    @noAction,

    [Description("LockWorkstation")]
    @lockWorkstation,

    [Description("ForceLogoff")]
    @forceLogoff,

    [Description("DisconnectRemoteDesktopSession")]
    @disconnectRemoteDesktopSession,
}
