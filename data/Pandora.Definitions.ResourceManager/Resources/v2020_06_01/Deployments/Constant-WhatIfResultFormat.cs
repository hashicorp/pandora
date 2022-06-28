using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.Deployments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WhatIfResultFormatConstant
{
    [Description("FullResourcePayloads")]
    FullResourcePayloads,

    [Description("ResourceIdOnly")]
    ResourceIdOnly,
}
