// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOutlookTaskAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOutlookTaskByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeOutlookTaskByIdAttachmentOperation(),
        new DeleteMeOutlookTaskByIdAttachmentByIdOperation(),
        new GetMeOutlookTaskByIdAttachmentByIdOperation(),
        new GetMeOutlookTaskByIdAttachmentCountOperation(),
        new ListMeOutlookTaskByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOutlookTaskByIdAttachmentCreateUploadSessionRequestModel)
    };
}
