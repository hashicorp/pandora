// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationDefenderOfficeAppsOtherProcessInjectionConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("Enable")]
    @enable,

    [Description("AuditMode")]
    @auditMode,

    [Description("Warn")]
    @warn,

    [Description("NotConfigured")]
    @notConfigured,
}
