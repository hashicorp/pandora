using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DaprLogLevelConstant
{
    [Description("debug")]
    Debug,

    [Description("error")]
    Error,

    [Description("info")]
    Info,

    [Description("warn")]
    Warn,
}
