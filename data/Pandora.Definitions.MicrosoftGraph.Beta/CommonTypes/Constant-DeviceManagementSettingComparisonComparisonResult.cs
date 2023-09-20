// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementSettingComparisonComparisonResultConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Equal")]
    @equal,

    [Description("NotEqual")]
    @notEqual,

    [Description("Added")]
    @added,

    [Description("Removed")]
    @removed,
}
