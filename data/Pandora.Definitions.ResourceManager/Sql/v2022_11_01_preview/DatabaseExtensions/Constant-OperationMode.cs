using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DatabaseExtensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationModeConstant
{
    [Description("Export")]
    Export,

    [Description("Import")]
    Import,

    [Description("PolybaseImport")]
    PolybaseImport,
}
