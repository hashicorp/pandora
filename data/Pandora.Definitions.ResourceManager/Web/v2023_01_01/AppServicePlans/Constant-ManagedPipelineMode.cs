using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServicePlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedPipelineModeConstant
{
    [Description("Classic")]
    Classic,

    [Description("Integrated")]
    Integrated,
}
