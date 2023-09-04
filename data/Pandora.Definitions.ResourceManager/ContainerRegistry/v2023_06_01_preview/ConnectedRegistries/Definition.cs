using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2023_06_01_preview.ConnectedRegistries;

internal class Definition : ResourceDefinition
{
    public string Name => "ConnectedRegistries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeactivateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActivationStatusConstant),
        typeof(AuditLogStatusConstant),
        typeof(CertificateTypeConstant),
        typeof(ConnectedRegistryModeConstant),
        typeof(ConnectionStateConstant),
        typeof(LogLevelConstant),
        typeof(ProvisioningStateConstant),
        typeof(TlsStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActivationPropertiesModel),
        typeof(ConnectedRegistryModel),
        typeof(ConnectedRegistryPropertiesModel),
        typeof(ConnectedRegistryUpdateParametersModel),
        typeof(ConnectedRegistryUpdatePropertiesModel),
        typeof(LoggingPropertiesModel),
        typeof(LoginServerPropertiesModel),
        typeof(ParentPropertiesModel),
        typeof(StatusDetailPropertiesModel),
        typeof(SyncPropertiesModel),
        typeof(SyncUpdatePropertiesModel),
        typeof(TlsCertificatePropertiesModel),
        typeof(TlsPropertiesModel),
    };
}
