using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.DatabaseExtensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationModeConstant
{
    [Description("PolybaseImport")]
    PolybaseImport,
}
