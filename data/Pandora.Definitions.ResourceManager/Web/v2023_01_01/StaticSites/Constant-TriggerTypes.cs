using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.StaticSites;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TriggerTypesConstant
{
    [Description("HttpTrigger")]
    HTTPTrigger,

    [Description("Unknown")]
    Unknown,
}
