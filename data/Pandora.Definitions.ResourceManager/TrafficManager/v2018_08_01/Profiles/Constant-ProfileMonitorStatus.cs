using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.Profiles
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ProfileMonitorStatus
    {
        [Description("CheckingEndpoints")]
        CheckingEndpoints,

        [Description("Degraded")]
        Degraded,

        [Description("Disabled")]
        Disabled,

        [Description("Inactive")]
        Inactive,

        [Description("Online")]
        Online,
    }
}
