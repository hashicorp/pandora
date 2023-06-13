using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.VirtualClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
