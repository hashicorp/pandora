using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Diagnostic;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationNameFormatConstant
{
    [Description("Name")]
    Name,

    [Description("Url")]
    Url,
}
