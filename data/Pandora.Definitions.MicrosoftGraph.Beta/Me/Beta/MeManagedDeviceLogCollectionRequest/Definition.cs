// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceLogCollectionRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "MeManagedDeviceLogCollectionRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeManagedDeviceByIdLogCollectionRequestByIdCreateDownloadUrlOperation(),
        new CreateMeManagedDeviceByIdLogCollectionRequestOperation(),
        new DeleteMeManagedDeviceByIdLogCollectionRequestByIdOperation(),
        new GetMeManagedDeviceByIdLogCollectionRequestByIdOperation(),
        new GetMeManagedDeviceByIdLogCollectionRequestCountOperation(),
        new ListMeManagedDeviceByIdLogCollectionRequestsOperation(),
        new UpdateMeManagedDeviceByIdLogCollectionRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
