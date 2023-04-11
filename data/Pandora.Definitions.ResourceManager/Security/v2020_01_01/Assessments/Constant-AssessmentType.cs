using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.Assessments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssessmentTypeConstant
{
    [Description("BuiltIn")]
    BuiltIn,

    [Description("CustomPolicy")]
    CustomPolicy,

    [Description("CustomerManaged")]
    CustomerManaged,

    [Description("VerifiedPartner")]
    VerifiedPartner,
}
