using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.DataConnectorsConnect;

internal class Definition : ResourceDefinition
{
    public string Name => "DataConnectorsConnect";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DataConnectorsConnectOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConnectAuthKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataConnectorConnectBodyModel),
    };
}
