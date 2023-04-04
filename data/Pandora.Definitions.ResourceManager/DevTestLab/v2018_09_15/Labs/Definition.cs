using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Labs;

internal class Definition : ResourceDefinition
{
    public string Name => "Labs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClaimAnyVMOperation(),
        new CreateEnvironmentOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExportResourceUsageOperation(),
        new GenerateUploadUriOperation(),
        new GetOperation(),
        new ImportVirtualMachineOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListVhdsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnableStatusConstant),
        typeof(EnvironmentPermissionConstant),
        typeof(HostCachingOptionsConstant),
        typeof(PremiumDataDiskConstant),
        typeof(StorageTypeConstant),
        typeof(TransportProtocolConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ArtifactInstallPropertiesModel),
        typeof(ArtifactParameterPropertiesModel),
        typeof(AttachNewDataDiskOptionsModel),
        typeof(BulkCreationParametersModel),
        typeof(DataDiskPropertiesModel),
        typeof(DayDetailsModel),
        typeof(ExportResourceUsageParametersModel),
        typeof(GalleryImageReferenceModel),
        typeof(GenerateUploadUriParameterModel),
        typeof(GenerateUploadUriResponseModel),
        typeof(HourDetailsModel),
        typeof(ImportLabVirtualMachineRequestModel),
        typeof(InboundNatRuleModel),
        typeof(LabModel),
        typeof(LabAnnouncementPropertiesModel),
        typeof(LabPropertiesModel),
        typeof(LabSupportPropertiesModel),
        typeof(LabVhdModel),
        typeof(LabVirtualMachineCreationParameterModel),
        typeof(LabVirtualMachineCreationParameterPropertiesModel),
        typeof(NetworkInterfacePropertiesModel),
        typeof(NotificationSettingsModel),
        typeof(ScheduleCreationParameterModel),
        typeof(ScheduleCreationParameterPropertiesModel),
        typeof(SharedPublicIPAddressConfigurationModel),
        typeof(UpdateResourceModel),
        typeof(WeekDetailsModel),
    };
}
