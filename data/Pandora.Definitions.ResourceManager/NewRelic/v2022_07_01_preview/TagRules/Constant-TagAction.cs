// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01_preview.TagRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TagActionConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,
}
