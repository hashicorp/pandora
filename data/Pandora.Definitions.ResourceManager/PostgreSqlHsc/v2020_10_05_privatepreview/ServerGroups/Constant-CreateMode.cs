using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum CreateModeConstant
    {
        [Description("Default")]
        Default,

        [Description("PointInTimeRestore")]
        PointInTimeRestore,

        [Description("ReadReplica")]
        ReadReplica,
    }
}
