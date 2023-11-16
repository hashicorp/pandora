using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.VirtualEndpoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VirtualEndpointTypeConstant
{
    [Description("ReadWrite")]
    ReadWrite,
}
