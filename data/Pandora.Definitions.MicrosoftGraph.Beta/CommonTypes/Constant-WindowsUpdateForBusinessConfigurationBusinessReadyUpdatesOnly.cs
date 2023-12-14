// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdateForBusinessConfigurationBusinessReadyUpdatesOnlyConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("All")]
    @all,

    [Description("BusinessReadyOnly")]
    @businessReadyOnly,

    [Description("WindowsInsiderBuildFast")]
    @windowsInsiderBuildFast,

    [Description("WindowsInsiderBuildSlow")]
    @windowsInsiderBuildSlow,

    [Description("WindowsInsiderBuildRelease")]
    @windowsInsiderBuildRelease,
}
