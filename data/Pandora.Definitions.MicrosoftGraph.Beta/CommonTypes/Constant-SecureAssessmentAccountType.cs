// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecureAssessmentAccountTypeConstant
{
    [Description("AzureADAccount")]
    @azureADAccount,

    [Description("DomainAccount")]
    @domainAccount,

    [Description("LocalAccount")]
    @localAccount,

    [Description("LocalGuestAccount")]
    @localGuestAccount,
}
