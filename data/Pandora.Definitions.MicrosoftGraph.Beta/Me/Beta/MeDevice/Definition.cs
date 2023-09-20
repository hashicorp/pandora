// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeDevice;

internal class Definition : ResourceDefinition
{
    public string Name => "MeDevice";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckMeDeviceByIdMemberGroupOperation(),
        new CheckMeDeviceByIdMemberObjectOperation(),
        new CreateMeDeviceOperation(),
        new DeleteMeDeviceByIdOperation(),
        new GetMeDeviceByIdMemberGroupOperation(),
        new GetMeDeviceByIdMemberObjectOperation(),
        new GetMeDeviceByIdOperation(),
        new GetMeDeviceCountOperation(),
        new GetMeDevicesByIdsOperation(),
        new GetMeDevicesUserOwnedObjectOperation(),
        new ListMeDevicesOperation(),
        new RestoreMeDeviceByIdOperation(),
        new UpdateMeDeviceByIdOperation(),
        new ValidateMeDevicesPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckMeDeviceByIdMemberGroupRequestModel),
        typeof(CheckMeDeviceByIdMemberObjectRequestModel),
        typeof(GetMeDeviceByIdMemberGroupRequestModel),
        typeof(GetMeDeviceByIdMemberObjectRequestModel),
        typeof(GetMeDevicesByIdsRequestModel),
        typeof(GetMeDevicesUserOwnedObjectRequestModel),
        typeof(ValidateMeDevicesPropertyRequestModel)
    };
}
