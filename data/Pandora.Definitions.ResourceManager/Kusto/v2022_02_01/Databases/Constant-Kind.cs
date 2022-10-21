using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("ReadOnlyFollowing")]
    ReadOnlyFollowing,

    [Description("ReadWrite")]
    ReadWrite,
}
