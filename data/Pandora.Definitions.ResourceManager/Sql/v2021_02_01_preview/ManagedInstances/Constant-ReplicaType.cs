using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicaTypeConstant
{
    [Description("Primary")]
    Primary,

    [Description("ReadableSecondary")]
    ReadableSecondary,
}
