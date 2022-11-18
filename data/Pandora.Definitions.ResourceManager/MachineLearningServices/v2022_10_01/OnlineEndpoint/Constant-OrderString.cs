using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OnlineEndpoint;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OrderStringConstant
{
    [Description("CreatedAtAsc")]
    CreatedAtAsc,

    [Description("CreatedAtDesc")]
    CreatedAtDesc,

    [Description("UpdatedAtAsc")]
    UpdatedAtAsc,

    [Description("UpdatedAtDesc")]
    UpdatedAtDesc,
}
