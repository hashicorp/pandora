// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChatMessagePolicyViolationDlpActionConstant
{
    [Description("None")]
    @none,

    [Description("NotifySender")]
    @notifySender,

    [Description("BlockAccess")]
    @blockAccess,

    [Description("BlockAccessExternal")]
    @blockAccessExternal,
}
