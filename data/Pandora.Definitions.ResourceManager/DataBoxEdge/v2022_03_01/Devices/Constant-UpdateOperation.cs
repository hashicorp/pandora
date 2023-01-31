using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateOperationConstant
{
    [Description("Download")]
    Download,

    [Description("Install")]
    Install,

    [Description("None")]
    None,

    [Description("Scan")]
    Scan,
}
