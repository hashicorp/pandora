using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Pipelines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DependencyConditionConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Skipped")]
    Skipped,

    [Description("Succeeded")]
    Succeeded,
}
