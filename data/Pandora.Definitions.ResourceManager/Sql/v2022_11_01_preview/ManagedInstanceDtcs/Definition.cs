using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedInstanceDtcs;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedInstanceDtcs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByManagedInstanceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceDtcModel),
        typeof(ManagedInstanceDtcPropertiesModel),
        typeof(ManagedInstanceDtcSecuritySettingsModel),
        typeof(ManagedInstanceDtcTransactionManagerCommunicationSettingsModel),
    };
}
