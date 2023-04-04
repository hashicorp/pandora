using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.LiveEvents;

internal class Definition : ResourceDefinition
{
    public string Name => "LiveEvents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AllocateOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ResetOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LiveEventEncodingTypeConstant),
        typeof(LiveEventInputProtocolConstant),
        typeof(LiveEventResourceStateConstant),
        typeof(StreamOptionsFlagConstant),
        typeof(StretchModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CrossSiteAccessPoliciesModel),
        typeof(IPAccessControlModel),
        typeof(IPRangeModel),
        typeof(LiveEventModel),
        typeof(LiveEventActionInputModel),
        typeof(LiveEventEncodingModel),
        typeof(LiveEventEndpointModel),
        typeof(LiveEventInputModel),
        typeof(LiveEventInputAccessControlModel),
        typeof(LiveEventInputTrackSelectionModel),
        typeof(LiveEventOutputTranscriptionTrackModel),
        typeof(LiveEventPreviewModel),
        typeof(LiveEventPreviewAccessControlModel),
        typeof(LiveEventPropertiesModel),
        typeof(LiveEventTranscriptionModel),
    };
}
