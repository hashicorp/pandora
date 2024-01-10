using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.DatabaseExtensions;

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
