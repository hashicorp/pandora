using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SubstatusConstant
{
    [Description("Approved")]
    Approved,

    [Description("Denied")]
    Denied,

    [Description("Expired")]
    Expired,

    [Description("Failed")]
    Failed,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Timeout")]
    Timeout,
}
