using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.NetworkStatus;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkStatus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByLocationOperation(),
        new ListByServiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessIdNameConstant),
        typeof(ConnectivityStatusTypeConstant),
        typeof(IdentityProviderTypeConstant),
        typeof(NotificationNameConstant),
        typeof(TemplateNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConnectivityStatusContractModel),
        typeof(NetworkStatusContractModel),
        typeof(NetworkStatusContractByLocationModel),
    };
}
