// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.Metadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScenarioConstant
{
    [Description("Alerts")]
    Alerts,
}
