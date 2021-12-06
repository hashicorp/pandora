using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.Databases
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ProtocolConstant
    {
        [Description("Encrypted")]
        Encrypted,

        [Description("Plaintext")]
        Plaintext,
    }
}
