// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2015_04_01.AutoscaleAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationTypeConstant
{
    [Description("Scale")]
    Scale,
}
