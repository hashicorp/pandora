using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentApiKeysAPIs;

internal class Definition : ResourceDefinition
{
    public string Name => "ComponentApiKeysAPIs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new APIKeysCreateOperation(),
        new APIKeysDeleteOperation(),
        new APIKeysGetOperation(),
        new APIKeysListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(APIKeyRequestModel),
        typeof(ApplicationInsightsComponentAPIKeyModel),
        typeof(ApplicationInsightsComponentAPIKeyListResultModel),
    };
}
