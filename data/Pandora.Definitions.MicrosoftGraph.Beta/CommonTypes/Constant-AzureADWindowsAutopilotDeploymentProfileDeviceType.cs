// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AzureADWindowsAutopilotDeploymentProfileDeviceTypeConstant
{
    [Description("WindowsPc")]
    @windowsPc,

    [Description("SurfaceHub2")]
    @surfaceHub2,

    [Description("HoloLens")]
    @holoLens,

    [Description("SurfaceHub2S")]
    @surfaceHub2S,

    [Description("VirtualMachine")]
    @virtualMachine,
}
