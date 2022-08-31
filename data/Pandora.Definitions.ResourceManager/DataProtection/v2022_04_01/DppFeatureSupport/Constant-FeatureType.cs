using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.DppFeatureSupport;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureTypeConstant
{
    [Description("DataSourceType")]
    DataSourceType,

    [Description("Invalid")]
    Invalid,
}
