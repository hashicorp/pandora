// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EndpointProtectionConfigurationApplicationGuardBlockFileTransferConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("BlockImageAndTextFile")]
    @blockImageAndTextFile,

    [Description("BlockImageFile")]
    @blockImageFile,

    [Description("BlockNone")]
    @blockNone,

    [Description("BlockTextFile")]
    @blockTextFile,
}
