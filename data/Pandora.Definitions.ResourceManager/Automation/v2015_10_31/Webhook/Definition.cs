using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Webhook;

internal class Definition : ResourceDefinition
{
    public string Name => "Webhook";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GenerateUriOperation(),
        new GetOperation(),
        new ListByAutomationAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(RunbookAssociationPropertyModel),
        typeof(WebhookModel),
        typeof(WebhookCreateOrUpdateParametersModel),
        typeof(WebhookCreateOrUpdatePropertiesModel),
        typeof(WebhookPropertiesModel),
        typeof(WebhookUpdateParametersModel),
        typeof(WebhookUpdatePropertiesModel),
    };
}
