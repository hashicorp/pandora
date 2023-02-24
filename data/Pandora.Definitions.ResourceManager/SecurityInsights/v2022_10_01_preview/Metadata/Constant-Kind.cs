using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Metadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("AnalyticsRule")]
    AnalyticsRule,

    [Description("AnalyticsRuleTemplate")]
    AnalyticsRuleTemplate,

    [Description("AutomationRule")]
    AutomationRule,

    [Description("AzureFunction")]
    AzureFunction,

    [Description("DataConnector")]
    DataConnector,

    [Description("DataType")]
    DataType,

    [Description("HuntingQuery")]
    HuntingQuery,

    [Description("InvestigationQuery")]
    InvestigationQuery,

    [Description("LogicAppsCustomConnector")]
    LogicAppsCustomConnector,

    [Description("Parser")]
    Parser,

    [Description("Playbook")]
    Playbook,

    [Description("PlaybookTemplate")]
    PlaybookTemplate,

    [Description("Solution")]
    Solution,

    [Description("Watchlist")]
    Watchlist,

    [Description("WatchlistTemplate")]
    WatchlistTemplate,

    [Description("Workbook")]
    Workbook,

    [Description("WorkbookTemplate")]
    WorkbookTemplate,
}
