// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOutlookTaskGroupTaskFolderTaskAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOutlookTaskGroupTaskFolderTaskAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentOperation(),
        new DeleteUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentByIdOperation(),
        new GetUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentByIdOperation(),
        new GetUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentCountOperation(),
        new ListUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOutlookTaskGroupByIdTaskFolderByIdTaskByIdAttachmentCreateUploadSessionRequestModel)
    };
}
