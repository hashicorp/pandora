// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementExportJobFormatConstant
{
    [Description("Csv")]
    @csv,

    [Description("Pdf")]
    @pdf,

    [Description("Json")]
    @json,
}
