using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.AnalyticsItemsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ItemTypeParameterConstant
{
    [Description("folder")]
    Folder,

    [Description("function")]
    Function,

    [Description("none")]
    None,

    [Description("query")]
    Query,

    [Description("recent")]
    Recent,
}
