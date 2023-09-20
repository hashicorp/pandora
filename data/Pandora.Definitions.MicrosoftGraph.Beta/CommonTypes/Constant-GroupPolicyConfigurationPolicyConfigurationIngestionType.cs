// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupPolicyConfigurationPolicyConfigurationIngestionTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Custom")]
    @custom,

    [Description("BuiltIn")]
    @builtIn,

    [Description("Mixed")]
    @mixed,
}
