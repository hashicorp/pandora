// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityIncidentDeterminationConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Apt")]
    @apt,

    [Description("Malware")]
    @malware,

    [Description("SecurityPersonnel")]
    @securityPersonnel,

    [Description("SecurityTesting")]
    @securityTesting,

    [Description("UnwantedSoftware")]
    @unwantedSoftware,

    [Description("Other")]
    @other,

    [Description("MultiStagedAttack")]
    @multiStagedAttack,

    [Description("CompromisedAccount")]
    @compromisedAccount,

    [Description("Phishing")]
    @phishing,

    [Description("MaliciousUserActivity")]
    @maliciousUserActivity,

    [Description("NotMalicious")]
    @notMalicious,

    [Description("NotEnoughDataToValidate")]
    @notEnoughDataToValidate,

    [Description("ConfirmedActivity")]
    @confirmedActivity,

    [Description("LineOfBusinessApplication")]
    @lineOfBusinessApplication,
}
