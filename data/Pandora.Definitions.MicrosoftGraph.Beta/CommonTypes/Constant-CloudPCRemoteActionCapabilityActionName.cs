// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCRemoteActionCapabilityActionNameConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Restart")]
    @restart,

    [Description("Rename")]
    @rename,

    [Description("Resize")]
    @resize,

    [Description("Restore")]
    @restore,

    [Description("Reprovision")]
    @reprovision,

    [Description("ChangeUserAccountType")]
    @changeUserAccountType,

    [Description("Troubleshoot")]
    @troubleshoot,

    [Description("PlaceUnderReview")]
    @placeUnderReview,

    [Description("CreateSnapshot")]
    @createSnapshot,

    [Description("PowerOn")]
    @powerOn,

    [Description("PowerOff")]
    @powerOff,

    [Description("MoveRegion")]
    @moveRegion,
}
