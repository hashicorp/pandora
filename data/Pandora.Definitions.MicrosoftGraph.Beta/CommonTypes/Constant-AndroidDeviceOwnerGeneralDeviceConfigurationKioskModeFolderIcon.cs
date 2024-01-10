// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerGeneralDeviceConfigurationKioskModeFolderIconConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("DarkSquare")]
    @darkSquare,

    [Description("DarkCircle")]
    @darkCircle,

    [Description("LightSquare")]
    @lightSquare,

    [Description("LightCircle")]
    @lightCircle,
}
