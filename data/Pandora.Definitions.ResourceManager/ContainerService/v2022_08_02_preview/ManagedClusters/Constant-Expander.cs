using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExpanderConstant
{
    [Description("least-waste")]
    LeastNegativewaste,

    [Description("most-pods")]
    MostNegativepods,

    [Description("priority")]
    Priority,

    [Description("random")]
    Random,
}
