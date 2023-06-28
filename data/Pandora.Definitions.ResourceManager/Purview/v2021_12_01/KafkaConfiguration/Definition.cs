using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Purview.v2021_12_01.KafkaConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "KafkaConfiguration";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CredentialsTypeConstant),
        typeof(EventHubTypeConstant),
        typeof(EventStreamingStateConstant),
        typeof(EventStreamingTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CredentialsModel),
        typeof(KafkaConfigurationModel),
        typeof(KafkaConfigurationPropertiesModel),
    };
}
