using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2021_05_01.DomainServices;

internal class Definition : ResourceDefinition
{
    public string Name => "DomainServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ExternalAccessConstant),
        typeof(FilteredSyncConstant),
        typeof(KerberosArmoringConstant),
        typeof(KerberosRc4EncryptionConstant),
        typeof(LdapsConstant),
        typeof(NotifyDcAdminsConstant),
        typeof(NotifyGlobalAdminsConstant),
        typeof(NtlmV1Constant),
        typeof(StatusConstant),
        typeof(SyncKerberosPasswordsConstant),
        typeof(SyncNtlmPasswordsConstant),
        typeof(SyncOnPremPasswordsConstant),
        typeof(TlsV1Constant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigDiagnosticsModel),
        typeof(ConfigDiagnosticsValidatorResultModel),
        typeof(ConfigDiagnosticsValidatorResultIssueModel),
        typeof(DomainSecuritySettingsModel),
        typeof(DomainServiceModel),
        typeof(DomainServicePropertiesModel),
        typeof(ForestTrustModel),
        typeof(HealthAlertModel),
        typeof(HealthMonitorModel),
        typeof(LdapsSettingsModel),
        typeof(MigrationProgressModel),
        typeof(MigrationPropertiesModel),
        typeof(NotificationSettingsModel),
        typeof(ReplicaSetModel),
        typeof(ResourceForestSettingsModel),
    };
}
