// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpirationRequirementConstant
{
    [Description("RememberMultifactorAuthenticationOnTrustedDevices")]
    @rememberMultifactorAuthenticationOnTrustedDevices,

    [Description("TenantTokenLifetimePolicy")]
    @tenantTokenLifetimePolicy,

    [Description("AudienceTokenLifetimePolicy")]
    @audienceTokenLifetimePolicy,

    [Description("SignInFrequencyPeriodicReauthentication")]
    @signInFrequencyPeriodicReauthentication,

    [Description("NgcMfa")]
    @ngcMfa,

    [Description("SignInFrequencyEveryTime")]
    @signInFrequencyEveryTime,
}
