// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallRoutingPoliciesConstant
{
    [Description("None")]
    @none,

    [Description("NoMissedCall")]
    @noMissedCall,

    [Description("DisableForwardingExceptPhone")]
    @disableForwardingExceptPhone,

    [Description("DisableForwarding")]
    @disableForwarding,

    [Description("PreferSkypeForBusiness")]
    @preferSkypeForBusiness,
}
