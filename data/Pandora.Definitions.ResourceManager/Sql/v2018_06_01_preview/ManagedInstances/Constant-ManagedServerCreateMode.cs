using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedServerCreateModeConstant
{
    [Description("Default")]
    Default,

    [Description("PointInTimeRestore")]
    PointInTimeRestore,
}
