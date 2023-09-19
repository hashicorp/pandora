// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeEventAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeEventAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeEventByIdAttachmentOperation(),
        new DeleteMeEventByIdAttachmentByIdOperation(),
        new GetMeEventByIdAttachmentByIdOperation(),
        new GetMeEventByIdAttachmentCountOperation(),
        new ListMeEventByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeEventByIdAttachmentCreateUploadSessionRequestModel)
    };
}
