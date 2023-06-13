using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.FailoverDatabases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReplicaTypeConstant
{
    [Description("Primary")]
    Primary,

    [Description("ReadableSecondary")]
    ReadableSecondary,
}
