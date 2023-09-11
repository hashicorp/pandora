using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.NotificationRecipientUser;

internal class Definition : ResourceDefinition
{
    public string Name => "NotificationRecipientUser";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckEntityExistsOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ListByNotificationOperation(),
        new WorkspaceNotificationRecipientUserCheckEntityExistsOperation(),
        new WorkspaceNotificationRecipientUserCreateOrUpdateOperation(),
        new WorkspaceNotificationRecipientUserDeleteOperation(),
        new WorkspaceNotificationRecipientUserListByNotificationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NotificationNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RecipientUserCollectionModel),
        typeof(RecipientUserContractModel),
        typeof(RecipientUsersContractPropertiesModel),
    };
}
