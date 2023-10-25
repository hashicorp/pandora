using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.BlobAuditing;

internal class Definition : ResourceDefinition
{
    public string Name => "BlobAuditing";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DatabaseBlobAuditingPoliciesCreateOrUpdateOperation(),
        new DatabaseBlobAuditingPoliciesGetOperation(),
        new DatabaseBlobAuditingPoliciesListByDatabaseOperation(),
        new ExtendedDatabaseBlobAuditingPoliciesCreateOrUpdateOperation(),
        new ExtendedDatabaseBlobAuditingPoliciesGetOperation(),
        new ExtendedDatabaseBlobAuditingPoliciesListByDatabaseOperation(),
        new ExtendedServerBlobAuditingPoliciesCreateOrUpdateOperation(),
        new ExtendedServerBlobAuditingPoliciesGetOperation(),
        new ExtendedServerBlobAuditingPoliciesListByServerOperation(),
        new ServerBlobAuditingPoliciesCreateOrUpdateOperation(),
        new ServerBlobAuditingPoliciesGetOperation(),
        new ServerBlobAuditingPoliciesListByServerOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BlobAuditingPolicyStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DatabaseBlobAuditingPolicyModel),
        typeof(DatabaseBlobAuditingPolicyPropertiesModel),
        typeof(ExtendedDatabaseBlobAuditingPolicyModel),
        typeof(ExtendedDatabaseBlobAuditingPolicyPropertiesModel),
        typeof(ExtendedServerBlobAuditingPolicyModel),
        typeof(ExtendedServerBlobAuditingPolicyPropertiesModel),
        typeof(ServerBlobAuditingPolicyModel),
        typeof(ServerBlobAuditingPolicyPropertiesModel),
    };
}
