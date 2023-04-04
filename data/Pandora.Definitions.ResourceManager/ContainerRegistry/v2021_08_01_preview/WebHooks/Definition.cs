using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_08_01_preview.WebHooks;

internal class Definition : ResourceDefinition
{
    public string Name => "WebHooks";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetCallbackConfigOperation(),
        new ListOperation(),
        new ListEventsOperation(),
        new PingOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(WebhookActionConstant),
        typeof(WebhookStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActorModel),
        typeof(CallbackConfigModel),
        typeof(EventModel),
        typeof(EventContentModel),
        typeof(EventInfoModel),
        typeof(EventRequestMessageModel),
        typeof(EventResponseMessageModel),
        typeof(RequestModel),
        typeof(SourceModel),
        typeof(TargetModel),
        typeof(WebhookModel),
        typeof(WebhookCreateParametersModel),
        typeof(WebhookPropertiesModel),
        typeof(WebhookPropertiesCreateParametersModel),
        typeof(WebhookPropertiesUpdateParametersModel),
        typeof(WebhookUpdateParametersModel),
    };
}
