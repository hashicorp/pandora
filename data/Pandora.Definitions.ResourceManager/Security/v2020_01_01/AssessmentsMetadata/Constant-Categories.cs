using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.AssessmentsMetadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CategoriesConstant
{
    [Description("Compute")]
    Compute,

    [Description("Data")]
    Data,

    [Description("IdentityAndAccess")]
    IdentityAndAccess,

    [Description("IoT")]
    IoT,

    [Description("Networking")]
    Networking,
}
