using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.DataSetMapping;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSetMappingStatusConstant
{
    [Description("Broken")]
    Broken,

    [Description("Ok")]
    Ok,
}
