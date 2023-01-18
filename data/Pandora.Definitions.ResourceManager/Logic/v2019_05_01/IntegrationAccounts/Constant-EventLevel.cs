using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccounts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventLevelConstant
{
    [Description("Critical")]
    Critical,

    [Description("Error")]
    Error,

    [Description("Informational")]
    Informational,

    [Description("LogAlways")]
    LogAlways,

    [Description("Verbose")]
    Verbose,

    [Description("Warning")]
    Warning,
}
