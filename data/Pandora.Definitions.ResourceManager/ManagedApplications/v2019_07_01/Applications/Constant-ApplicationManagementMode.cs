using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationManagementModeConstant
{
    [Description("Managed")]
    Managed,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Unmanaged")]
    Unmanaged,
}
