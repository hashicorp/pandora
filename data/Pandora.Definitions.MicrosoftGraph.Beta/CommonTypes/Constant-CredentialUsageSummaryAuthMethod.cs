// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CredentialUsageSummaryAuthMethodConstant
{
    [Description("Email")]
    @email,

    [Description("MobileSMS")]
    @mobileSMS,

    [Description("MobileCall")]
    @mobileCall,

    [Description("OfficePhone")]
    @officePhone,

    [Description("SecurityQuestion")]
    @securityQuestion,

    [Description("AppNotification")]
    @appNotification,

    [Description("AppCode")]
    @appCode,

    [Description("AlternateMobileCall")]
    @alternateMobileCall,

    [Description("Fido")]
    @fido,

    [Description("AppPassword")]
    @appPassword,
}
