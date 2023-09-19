// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserRegistrationDetailsDefaultMfaMethodConstant
{
    [Description("None")]
    @none,

    [Description("MobilePhone")]
    @mobilePhone,

    [Description("AlternateMobilePhone")]
    @alternateMobilePhone,

    [Description("OfficePhone")]
    @officePhone,

    [Description("MicrosoftAuthenticatorPush")]
    @microsoftAuthenticatorPush,

    [Description("SoftwareOneTimePasscode")]
    @softwareOneTimePasscode,
}
