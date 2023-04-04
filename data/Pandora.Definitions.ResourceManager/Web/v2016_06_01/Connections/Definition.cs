using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.Connections;

internal class Definition : ResourceDefinition
{
    public string Name => "Connections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConfirmConsentCodeOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListConsentLinksOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LinkStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiConnectionDefinitionModel),
        typeof(ApiConnectionDefinitionCollectionModel),
        typeof(ApiConnectionDefinitionPropertiesModel),
        typeof(ApiConnectionTestLinkModel),
        typeof(ApiReferenceModel),
        typeof(ConfirmConsentCodeDefinitionModel),
        typeof(ConnectionErrorModel),
        typeof(ConnectionErrorPropertiesModel),
        typeof(ConnectionStatusDefinitionModel),
        typeof(ConsentLinkCollectionModel),
        typeof(ConsentLinkDefinitionModel),
        typeof(ConsentLinkParameterDefinitionModel),
        typeof(ListConsentLinksDefinitionModel),
    };
}
