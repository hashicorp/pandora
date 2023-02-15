using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.PortalRevision;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PortalRevisionStatusConstant
{
    [Description("completed")]
    Completed,

    [Description("failed")]
    Failed,

    [Description("pending")]
    Pending,

    [Description("publishing")]
    Publishing,
}
