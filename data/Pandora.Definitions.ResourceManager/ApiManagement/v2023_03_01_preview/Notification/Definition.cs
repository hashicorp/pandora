using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Notification;

internal class Definition : ResourceDefinition
{
    public string Name => "Notification";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByServiceOperation(),
        new WorkspaceNotificationCreateOrUpdateOperation(),
        new WorkspaceNotificationGetOperation(),
        new WorkspaceNotificationListByServiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NotificationNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NotificationContractModel),
        typeof(NotificationContractPropertiesModel),
        typeof(RecipientsContractPropertiesModel),
    };
}
