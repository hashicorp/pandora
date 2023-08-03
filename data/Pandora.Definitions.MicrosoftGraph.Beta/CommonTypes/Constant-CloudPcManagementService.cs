// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPcManagementServiceConstant
{
    [Description("Windows365")]
    @windows365,

    [Description("DevBox")]
    @devBox,

    [Description("RpaBox")]
    @rpaBox,
}
