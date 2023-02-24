using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Triggerruns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerRunStatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Inprogress")]
    Inprogress,

    [Description("Succeeded")]
    Succeeded,
}
