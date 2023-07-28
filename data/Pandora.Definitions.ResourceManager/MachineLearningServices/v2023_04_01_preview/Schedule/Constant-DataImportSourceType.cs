using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Schedule;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataImportSourceTypeConstant
{
    [Description("database")]
    Database,

    [Description("file_system")]
    FileSystem,
}
