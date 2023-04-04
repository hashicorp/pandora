using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachines";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddDataDiskOperation(),
        new ApplyArtifactsOperation(),
        new ClaimOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DetachDataDiskOperation(),
        new GetOperation(),
        new GetRdpFileContentsOperation(),
        new ListOperation(),
        new ListApplicableSchedulesOperation(),
        new RedeployOperation(),
        new ResizeOperation(),
        new RestartOperation(),
        new StartOperation(),
        new StopOperation(),
        new TransferDisksOperation(),
        new UnClaimOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnableStatusConstant),
        typeof(HostCachingOptionsConstant),
        typeof(StorageTypeConstant),
        typeof(TransportProtocolConstant),
        typeof(VirtualMachineCreationSourceConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplicableScheduleModel),
        typeof(ApplicableSchedulePropertiesModel),
        typeof(ApplyArtifactsRequestModel),
        typeof(ArtifactDeploymentStatusPropertiesModel),
        typeof(ArtifactInstallPropertiesModel),
        typeof(ArtifactParameterPropertiesModel),
        typeof(AttachNewDataDiskOptionsModel),
        typeof(ComputeDataDiskModel),
        typeof(ComputeVMInstanceViewStatusModel),
        typeof(ComputeVMPropertiesModel),
        typeof(DataDiskPropertiesModel),
        typeof(DayDetailsModel),
        typeof(DetachDataDiskPropertiesModel),
        typeof(GalleryImageReferenceModel),
        typeof(HourDetailsModel),
        typeof(InboundNatRuleModel),
        typeof(LabVirtualMachineModel),
        typeof(LabVirtualMachinePropertiesModel),
        typeof(NetworkInterfacePropertiesModel),
        typeof(NotificationSettingsModel),
        typeof(RdpConnectionModel),
        typeof(ResizeLabVirtualMachinePropertiesModel),
        typeof(ScheduleModel),
        typeof(ScheduleCreationParameterModel),
        typeof(ScheduleCreationParameterPropertiesModel),
        typeof(SchedulePropertiesModel),
        typeof(SharedPublicIPAddressConfigurationModel),
        typeof(UpdateResourceModel),
        typeof(WeekDetailsModel),
    };
}
