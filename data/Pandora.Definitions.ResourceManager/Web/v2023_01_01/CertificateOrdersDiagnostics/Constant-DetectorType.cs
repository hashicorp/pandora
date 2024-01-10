using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.CertificateOrdersDiagnostics;

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
