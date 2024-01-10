using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_04_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownSyslogDataSourceFacilityNamesConstant
{
    [Description("alert")]
    Alert,

    [Description("*")]
    Any,

    [Description("audit")]
    Audit,

    [Description("auth")]
    Auth,

    [Description("authpriv")]
    Authpriv,

    [Description("clock")]
    Clock,

    [Description("cron")]
    Cron,

    [Description("daemon")]
    Daemon,

    [Description("ftp")]
    Ftp,

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

    [Description("nopri")]
    Nopri,

    [Description("ntp")]
    Ntp,

    [Description("syslog")]
    Syslog,

    [Description("user")]
    User,

    [Description("uucp")]
    Uucp,
}
