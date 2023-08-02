using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2023_06_07.Lab;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateOptionConstant
{
    [Description("Image")]
    Image,

    [Description("TemplateVM")]
    TemplateVM,
}
