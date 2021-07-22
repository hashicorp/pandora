using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.Namespaces
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum KeySource
    {
        [Description("Microsoft.KeyVault")]
        MicrosoftKeyVault,
    }
}
