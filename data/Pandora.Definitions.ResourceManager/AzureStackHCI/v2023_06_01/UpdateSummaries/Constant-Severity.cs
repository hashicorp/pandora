// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_06_01.UpdateSummaries;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SeverityConstant
{
    [Description("Critical")]
    Critical,

    [Description("Hidden")]
    Hidden,

    [Description("Informational")]
    Informational,

    [Description("Warning")]
    Warning,
}
