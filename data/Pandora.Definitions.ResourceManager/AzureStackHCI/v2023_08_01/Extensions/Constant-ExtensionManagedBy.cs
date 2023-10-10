using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_08_01.Extensions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ExtensionManagedByConstant
{
    [Description("Azure")]
    Azure,

    [Description("User")]
    User,
}
