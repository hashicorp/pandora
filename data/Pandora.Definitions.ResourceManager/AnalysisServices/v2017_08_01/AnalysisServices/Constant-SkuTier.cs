using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.AnalysisServices
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum SkuTierConstant
    {
        [Description("Basic")]
        Basic,

        [Description("Development")]
        Development,

        [Description("Standard")]
        Standard,
    }
}
