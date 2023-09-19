// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConditionalAccessTemplateScenariosConstant
{
    [Description("New")]
    @new,

    [Description("SecureFoundation")]
    @secureFoundation,

    [Description("ZeroTrust")]
    @zeroTrust,

    [Description("RemoteWork")]
    @remoteWork,

    [Description("ProtectAdmins")]
    @protectAdmins,

    [Description("EmergingThreats")]
    @emergingThreats,
}
