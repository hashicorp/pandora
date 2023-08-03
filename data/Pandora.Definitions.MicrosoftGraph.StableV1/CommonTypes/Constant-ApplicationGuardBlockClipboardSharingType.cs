// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationGuardBlockClipboardSharingTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("BlockBoth")]
    @blockBoth,

    [Description("BlockHostToContainer")]
    @blockHostToContainer,

    [Description("BlockContainerToHost")]
    @blockContainerToHost,

    [Description("BlockNone")]
    @blockNone,
}
