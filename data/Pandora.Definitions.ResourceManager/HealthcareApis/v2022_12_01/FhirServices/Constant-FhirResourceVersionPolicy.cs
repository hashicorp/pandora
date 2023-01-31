using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2022_12_01.FhirServices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FhirResourceVersionPolicyConstant
{
    [Description("no-version")]
    NoNegativeversion,

    [Description("versioned")]
    Versioned,

    [Description("versioned-update")]
    VersionedNegativeupdate,
}
