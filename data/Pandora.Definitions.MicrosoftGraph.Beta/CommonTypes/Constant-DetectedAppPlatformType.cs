// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DetectedAppPlatformTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Windows")]
    @windows,

    [Description("WindowsMobile")]
    @windowsMobile,

    [Description("WindowsHolographic")]
    @windowsHolographic,

    [Description("Ios")]
    @ios,

    [Description("MacOS")]
    @macOS,

    [Description("ChromeOS")]
    @chromeOS,

    [Description("AndroidOSP")]
    @androidOSP,

    [Description("AndroidDeviceAdministrator")]
    @androidDeviceAdministrator,

    [Description("AndroidWorkProfile")]
    @androidWorkProfile,

    [Description("AndroidDedicatedAndFullyManaged")]
    @androidDedicatedAndFullyManaged,
}
