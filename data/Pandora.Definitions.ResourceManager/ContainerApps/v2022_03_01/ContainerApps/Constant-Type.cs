using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("Liveness")]
    Liveness,

    [Description("Readiness")]
    Readiness,

    [Description("Startup")]
    Startup,
}
