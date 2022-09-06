using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.VolumeGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTargetTypeConstant
{
    [Description("Iscsi")]
    Iscsi,

    [Description("None")]
    None,
}
