using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_06_01.FhirServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FhirServiceKindConstant
{
    [Description("fhir-R4")]
    FhirNegativeRFour,

    [Description("fhir-Stu3")]
    FhirNegativeStuThree,
}
