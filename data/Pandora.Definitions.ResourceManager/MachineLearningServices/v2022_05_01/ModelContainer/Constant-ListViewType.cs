using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.ModelContainer;

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
