// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KerberosSignOnMappingAttributeTypeConstant
{
    [Description("UserPrincipalName")]
    @userPrincipalName,

    [Description("OnPremisesUserPrincipalName")]
    @onPremisesUserPrincipalName,

    [Description("UserPrincipalUsername")]
    @userPrincipalUsername,

    [Description("OnPremisesUserPrincipalUsername")]
    @onPremisesUserPrincipalUsername,

    [Description("OnPremisesSAMAccountName")]
    @onPremisesSAMAccountName,
}
