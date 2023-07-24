using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Diagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DetectorTypeConstant
{
    [Description("Analysis")]
    Analysis,

    [Description("CategoryOverview")]
    CategoryOverview,

    [Description("Detector")]
    Detector,
}
