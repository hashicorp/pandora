using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiManagementService;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PlatformVersionConstant
{
    [Description("mtv1")]
    MtvOne,

    [Description("stv1")]
    StvOne,

    [Description("stv2")]
    StvTwo,

    [Description("undetermined")]
    Undetermined,
}
