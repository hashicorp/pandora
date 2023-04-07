using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Elevate")]
    Elevate,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Remove")]
    Remove,
}
