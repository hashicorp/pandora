using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Formulas;

internal class Definition : ResourceDefinition
{
    public string Name => "Formulas";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnableStatusConstant),
        typeof(HostCachingOptionsConstant),
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
        typeof(FormulaModel),
        typeof(FormulaPropertiesModel),
        typeof(FormulaPropertiesFromVMModel),
        typeof(GalleryImageReferenceModel),
        typeof(HourDetailsModel),
        typeof(InboundNatRuleModel),
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
