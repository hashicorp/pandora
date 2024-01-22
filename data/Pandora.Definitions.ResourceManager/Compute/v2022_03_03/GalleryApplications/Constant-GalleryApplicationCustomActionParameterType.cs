// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.GalleryApplications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GalleryApplicationCustomActionParameterTypeConstant
{
    [Description("ConfigurationDataBlob")]
    ConfigurationDataBlob,

    [Description("LogOutputBlob")]
    LogOutputBlob,

    [Description("String")]
    String,
}
