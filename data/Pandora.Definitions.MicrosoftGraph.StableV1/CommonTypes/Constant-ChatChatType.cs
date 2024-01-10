// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ChatChatTypeConstant
{
    [Description("OneOnOne")]
    @oneOnOne,

    [Description("Group")]
    @group,

    [Description("Meeting")]
    @meeting,
}
