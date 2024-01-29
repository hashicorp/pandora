// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationProtectionContainerMappings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomationAccountAuthenticationTypeConstant
{
    [Description("RunAsAccount")]
    RunAsAccount,

    [Description("SystemAssignedIdentity")]
    SystemAssignedIdentity,
}
