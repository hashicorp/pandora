// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RiskUserActivityEventTypesConstant
{
    [Description("UnlikelyTravel")]
    @unlikelyTravel,

    [Description("AnonymizedIPAddress")]
    @anonymizedIPAddress,

    [Description("MaliciousIPAddress")]
    @maliciousIPAddress,

    [Description("UnfamiliarFeatures")]
    @unfamiliarFeatures,

    [Description("MalwareInfectedIPAddress")]
    @malwareInfectedIPAddress,

    [Description("SuspiciousIPAddress")]
    @suspiciousIPAddress,

    [Description("LeakedCredentials")]
    @leakedCredentials,

    [Description("InvestigationsThreatIntelligence")]
    @investigationsThreatIntelligence,

    [Description("Generic")]
    @generic,

    [Description("AdminConfirmedUserCompromised")]
    @adminConfirmedUserCompromised,

    [Description("McasImpossibleTravel")]
    @mcasImpossibleTravel,

    [Description("McasSuspiciousInboxManipulationRules")]
    @mcasSuspiciousInboxManipulationRules,

    [Description("InvestigationsThreatIntelligenceSigninLinked")]
    @investigationsThreatIntelligenceSigninLinked,

    [Description("MaliciousIPAddressValidCredentialsBlockedIP")]
    @maliciousIPAddressValidCredentialsBlockedIP,
}
