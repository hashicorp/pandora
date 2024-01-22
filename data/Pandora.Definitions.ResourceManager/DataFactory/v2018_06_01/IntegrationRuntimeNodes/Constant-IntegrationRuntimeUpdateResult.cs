// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimeNodes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationRuntimeUpdateResultConstant
{
    [Description("Fail")]
    Fail,

    [Description("None")]
    None,

    [Description("Succeed")]
    Succeed,
}
