using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview.FhirServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FhirServiceKindConstant
{
    [Description("fhir-R4")]
    FhirNegativeRFour,

    [Description("fhir-Stu3")]
    FhirNegativeStuThree,
}
