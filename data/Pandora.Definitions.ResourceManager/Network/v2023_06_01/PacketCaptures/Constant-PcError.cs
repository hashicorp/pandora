// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.PacketCaptures;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PcErrorConstant
{
    [Description("AgentStopped")]
    AgentStopped,

    [Description("CaptureFailed")]
    CaptureFailed,

    [Description("InternalError")]
    InternalError,

    [Description("LocalFileFailed")]
    LocalFileFailed,

    [Description("StorageFailed")]
    StorageFailed,
}
