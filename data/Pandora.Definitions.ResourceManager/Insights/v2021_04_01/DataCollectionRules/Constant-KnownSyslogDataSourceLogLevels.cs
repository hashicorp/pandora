using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownSyslogDataSourceLogLevelsConstant
{
    [Description("Alert")]
    Alert,

    [Description("*")]
    Any,

    [Description("Critical")]
    Critical,

    [Description("Debug")]
    Debug,

    [Description("Emergency")]
    Emergency,

    [Description("Error")]
    Error,

    [Description("Info")]
    Info,

    [Description("Notice")]
    Notice,

    [Description("Warning")]
    Warning,
}
