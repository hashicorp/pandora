// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsAutopilotDeviceIdentityDeploymentProfileAssignmentDetailedStatusConstant
{
    [Description("None")]
    @none,

    [Description("HardwareRequirementsNotMet")]
    @hardwareRequirementsNotMet,

    [Description("SurfaceHubProfileNotSupported")]
    @surfaceHubProfileNotSupported,

    [Description("HoloLensProfileNotSupported")]
    @holoLensProfileNotSupported,

    [Description("WindowsPcProfileNotSupported")]
    @windowsPcProfileNotSupported,

    [Description("SurfaceHub2SProfileNotSupported")]
    @surfaceHub2SProfileNotSupported,
}
