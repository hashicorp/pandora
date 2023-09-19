// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidImportedPFXCertificateProfileSubjectAlternativeNameTypeConstant
{
    [Description("None")]
    @none,

    [Description("EmailAddress")]
    @emailAddress,

    [Description("UserPrincipalName")]
    @userPrincipalName,

    [Description("CustomAzureADAttribute")]
    @customAzureADAttribute,

    [Description("DomainNameService")]
    @domainNameService,

    [Description("UniversalResourceIdentifier")]
    @universalResourceIdentifier,
}
