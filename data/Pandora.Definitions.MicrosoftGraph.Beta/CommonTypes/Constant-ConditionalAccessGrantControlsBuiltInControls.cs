// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalAccessGrantControlsBuiltInControlsConstant
{
    [Description("Block")]
    @block,

    [Description("Mfa")]
    @mfa,

    [Description("CompliantDevice")]
    @compliantDevice,

    [Description("DomainJoinedDevice")]
    @domainJoinedDevice,

    [Description("ApprovedApplication")]
    @approvedApplication,

    [Description("CompliantApplication")]
    @compliantApplication,

    [Description("PasswordChange")]
    @passwordChange,
}
