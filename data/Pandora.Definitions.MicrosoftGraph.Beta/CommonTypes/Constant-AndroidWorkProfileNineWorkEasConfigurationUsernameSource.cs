// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidWorkProfileNineWorkEasConfigurationUsernameSourceConstant
{
    [Description("Username")]
    @username,

    [Description("UserPrincipalName")]
    @userPrincipalName,

    [Description("SamAccountName")]
    @samAccountName,

    [Description("PrimarySmtpAddress")]
    @primarySmtpAddress,
}
