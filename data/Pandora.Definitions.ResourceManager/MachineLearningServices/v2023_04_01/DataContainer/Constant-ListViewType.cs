using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.DataContainer;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ListViewTypeConstant
{
    [Description("ActiveOnly")]
    ActiveOnly,

    [Description("All")]
    All,

    [Description("ArchivedOnly")]
    ArchivedOnly,
}
