using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JitApproverTypeConstant
{
    [Description("group")]
    Group,

    [Description("user")]
    User,
}
