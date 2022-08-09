using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.IotDpsResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessRightsDescriptionConstant
{
    [Description("DeviceConnect")]
    DeviceConnect,

    [Description("EnrollmentRead")]
    EnrollmentRead,

    [Description("EnrollmentWrite")]
    EnrollmentWrite,

    [Description("RegistrationStatusRead")]
    RegistrationStatusRead,

    [Description("RegistrationStatusWrite")]
    RegistrationStatusWrite,

    [Description("ServiceConfig")]
    ServiceConfig,
}
