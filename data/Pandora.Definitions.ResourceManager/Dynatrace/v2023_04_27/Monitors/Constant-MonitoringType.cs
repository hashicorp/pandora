using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2023_04_27.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitoringTypeConstant
{
    [Description("CLOUD_INFRASTRUCTURE")]
    CLOUDINFRASTRUCTURE,

    [Description("FULL_STACK")]
    FULLSTACK,
}
