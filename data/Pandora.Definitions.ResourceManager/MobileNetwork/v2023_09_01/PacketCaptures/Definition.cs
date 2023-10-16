using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_09_01.PacketCaptures;

internal class Definition : ResourceDefinition
{
    public string Name => "PacketCaptures";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByPacketCoreControlPlaneOperation(),
        new StopOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PacketCaptureStatusConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsyncOperationStatusModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(PacketCaptureModel),
        typeof(PacketCapturePropertiesFormatModel),
    };
}
