using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.EventHubs;

internal class Definition : ResourceDefinition
{
    public string Name => "EventHubs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new DeleteAuthorizationRuleOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new ListByNamespaceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(EncodingCaptureDescriptionConstant),
        typeof(EntityStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizationRuleModel),
        typeof(AuthorizationRulePropertiesModel),
        typeof(CaptureDescriptionModel),
        typeof(DestinationModel),
        typeof(DestinationPropertiesModel),
        typeof(EventhubModel),
        typeof(EventhubPropertiesModel),
    };
}
