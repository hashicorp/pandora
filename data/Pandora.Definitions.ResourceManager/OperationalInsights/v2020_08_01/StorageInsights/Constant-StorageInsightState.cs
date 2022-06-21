using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2020_08_01.StorageInsights;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageInsightStateConstant
{
    [Description("ERROR")]
    ERROR,

    [Description("OK")]
    OK,
}
