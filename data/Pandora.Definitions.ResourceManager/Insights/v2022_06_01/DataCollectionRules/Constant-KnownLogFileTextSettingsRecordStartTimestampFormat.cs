using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownLogFileTextSettingsRecordStartTimestampFormatConstant
{
    [Description("dd/MMM/yyyy:HH:mm:ss zzz")]
    DdMMMYyyyHHMmSsZzz,

    [Description("ddMMyy HH:mm:ss")]
    DdMMyyHHMmSs,

    [Description("ISO 8601")]
    ISOEightSixZeroOne,

    [Description("M/D/YYYY HH:MM:SS AM/PM")]
    MDYYYYHHMMSSAMPM,

    [Description("MMM d hh:mm:ss")]
    MMMDHhMmSs,

    [Description("Mon DD, YYYY HH:MM:SS")]
    MonDDYYYYHHMMSS,

    [Description("YYYY-MM-DD HH:MM:SS")]
    YYYYNegativeMMNegativeDDHHMMSS,

    [Description("yyMMdd HH:mm:ss")]
    YyMMddHHMmSs,

    [Description("yyyy-MM-ddTHH:mm:ssK")]
    YyyyNegativeMMNegativeddTHHMmSsK,
}
