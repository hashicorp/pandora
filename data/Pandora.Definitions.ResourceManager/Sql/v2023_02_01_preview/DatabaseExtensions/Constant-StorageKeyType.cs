using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseExtensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageKeyTypeConstant
{
    [Description("SharedAccessKey")]
    SharedAccessKey,

    [Description("StorageAccessKey")]
    StorageAccessKey,
}
