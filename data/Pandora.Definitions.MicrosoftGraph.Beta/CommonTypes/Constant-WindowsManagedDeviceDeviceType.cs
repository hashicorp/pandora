// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsManagedDeviceDeviceTypeConstant
{
    [Description("Desktop")]
    @desktop,

    [Description("WindowsRT")]
    @windowsRT,

    [Description("WinMO6")]
    @winMO6,

    [Description("Nokia")]
    @nokia,

    [Description("WindowsPhone")]
    @windowsPhone,

    [Description("Mac")]
    @mac,

    [Description("WinCE")]
    @winCE,

    [Description("WinEmbedded")]
    @winEmbedded,

    [Description("IPhone")]
    @iPhone,

    [Description("IPad")]
    @iPad,

    [Description("IPod")]
    @iPod,

    [Description("Android")]
    @android,

    [Description("ISocConsumer")]
    @iSocConsumer,

    [Description("Unix")]
    @unix,

    [Description("MacMDM")]
    @macMDM,

    [Description("HoloLens")]
    @holoLens,

    [Description("SurfaceHub")]
    @surfaceHub,

    [Description("AndroidForWork")]
    @androidForWork,

    [Description("AndroidEnterprise")]
    @androidEnterprise,

    [Description("Windows10x")]
    @windows10x,

    [Description("AndroidnGMS")]
    @androidnGMS,

    [Description("ChromeOS")]
    @chromeOS,

    [Description("Linux")]
    @linux,

    [Description("Blackberry")]
    @blackberry,

    [Description("Palm")]
    @palm,

    [Description("Unknown")]
    @unknown,

    [Description("CloudPC")]
    @cloudPC,
}
