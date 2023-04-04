using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Lab;

internal class Definition : ResourceDefinition
{
    public string Name => "Lab";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new PublishOperation(),
        new SyncGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectionTypeConstant),
        typeof(CreateOptionConstant),
        typeof(EnableStateConstant),
        typeof(LabStateConstant),
        typeof(OsTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ShutdownOnIdleModeConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoShutdownProfileModel),
        typeof(ConnectionProfileModel),
        typeof(CredentialsModel),
        typeof(ImageReferenceModel),
        typeof(LabModel),
        typeof(LabNetworkProfileModel),
        typeof(LabPropertiesModel),
        typeof(LabUpdateModel),
        typeof(LabUpdatePropertiesModel),
        typeof(RosterProfileModel),
        typeof(SecurityProfileModel),
        typeof(SkuModel),
        typeof(VirtualMachineAdditionalCapabilitiesModel),
        typeof(VirtualMachineProfileModel),
    };
}
