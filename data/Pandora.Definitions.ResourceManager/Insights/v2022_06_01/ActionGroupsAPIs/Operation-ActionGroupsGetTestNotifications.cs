using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.ActionGroupsAPIs;

internal class ActionGroupsGetTestNotificationsOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new NotificationStatusId();

    public override Type? ResponseObject() => typeof(TestNotificationDetailsResponseModel);


}
