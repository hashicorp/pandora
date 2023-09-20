// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationDefenderOfficeAppsLaunchChildProcessTypeConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("Block")]
    @block,

    [Description("AuditMode")]
    @auditMode,

    [Description("Warn")]
    @warn,

    [Description("Disable")]
    @disable,
}
