// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationApplicationGuardBlockClipboardSharingConstant
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
