using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Communication.v2020_08_20.CommunicationService
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum CreatedByTypeConstant
    {
        [Description("Application")]
        Application,

        [Description("Key")]
        Key,

        [Description("ManagedIdentity")]
        ManagedIdentity,

        [Description("User")]
        User,
    }
}
