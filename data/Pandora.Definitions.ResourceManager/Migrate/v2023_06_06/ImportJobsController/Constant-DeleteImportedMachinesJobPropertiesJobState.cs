using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportJobsController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeleteImportedMachinesJobPropertiesJobStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("Failed")]
    Failed,

    [Description("Unknown")]
    Unknown,

    [Description("Verified")]
    Verified,

    [Description("VerifiedWithErrors")]
    VerifiedWithErrors,
}
