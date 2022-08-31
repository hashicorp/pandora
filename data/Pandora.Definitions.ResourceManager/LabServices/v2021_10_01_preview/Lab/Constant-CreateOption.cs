using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateOptionConstant
{
    [Description("Image")]
    Image,

    [Description("TemplateVM")]
    TemplateVM,
}
