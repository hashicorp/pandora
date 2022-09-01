using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownSyslogDataSourceFacilityNamesConstant
{
    [Description("*")]
    Any,

    [Description("auth")]
    Auth,

    [Description("authpriv")]
    Authpriv,

    [Description("cron")]
    Cron,

    [Description("daemon")]
    Daemon,

    [Description("kern")]
    Kern,

    [Description("local5")]
    LocalFive,

    [Description("local4")]
    LocalFour,

    [Description("local1")]
    LocalOne,

    [Description("local7")]
    LocalSeven,

    [Description("local6")]
    LocalSix,

    [Description("local3")]
    LocalThree,

    [Description("local2")]
    LocalTwo,

    [Description("local0")]
    LocalZero,

    [Description("lpr")]
    Lpr,

    [Description("mail")]
    Mail,

    [Description("mark")]
    Mark,

    [Description("news")]
    News,

    [Description("syslog")]
    Syslog,

    [Description("user")]
    User,

    [Description("uucp")]
    Uucp,
}
