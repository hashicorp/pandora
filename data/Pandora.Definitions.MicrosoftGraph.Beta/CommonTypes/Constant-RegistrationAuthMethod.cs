// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistrationAuthMethodConstant
{
    [Description("Email")]
    @email,

    [Description("MobilePhone")]
    @mobilePhone,

    [Description("OfficePhone")]
    @officePhone,

    [Description("SecurityQuestion")]
    @securityQuestion,

    [Description("AppNotification")]
    @appNotification,

    [Description("AppCode")]
    @appCode,

    [Description("AlternateMobilePhone")]
    @alternateMobilePhone,

    [Description("Fido")]
    @fido,

    [Description("AppPassword")]
    @appPassword,
}
