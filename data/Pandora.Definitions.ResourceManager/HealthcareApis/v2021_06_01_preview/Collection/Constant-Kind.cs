using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2021_06_01_preview.Collection;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("fhir")]
    Fhir,

    [Description("fhir-R4")]
    FhirNegativeRFour,

    [Description("fhir-Stu3")]
    FhirNegativeStuThree,
}
