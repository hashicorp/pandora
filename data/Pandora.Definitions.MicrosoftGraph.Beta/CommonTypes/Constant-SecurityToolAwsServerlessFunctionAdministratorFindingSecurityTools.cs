// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityToolAwsServerlessFunctionAdministratorFindingSecurityToolsConstant
{
    [Description("Macie")]
    @macie,

    [Description("WafShield")]
    @wafShield,

    [Description("CloudTrail")]
    @cloudTrail,

    [Description("Inspector")]
    @inspector,

    [Description("SecurityHub")]
    @securityHub,

    [Description("Detective")]
    @detective,

    [Description("GuardDuty")]
    @guardDuty,
}
