// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "Beta";
    public bool Preview => true;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ServicePrincipal.Definition(),
        new ServicePrincipalAppManagementPolicy.Definition(),
        new ServicePrincipalAppRoleAssignedTo.Definition(),
        new ServicePrincipalAppRoleAssignment.Definition(),
        new ServicePrincipalClaimsMappingPolicy.Definition(),
        new ServicePrincipalCreatedObject.Definition(),
        new ServicePrincipalDelegatedPermissionClassification.Definition(),
        new ServicePrincipalEndpoint.Definition(),
        new ServicePrincipalFederatedIdentityCredential.Definition(),
        new ServicePrincipalHomeRealmDiscoveryPolicy.Definition(),
        new ServicePrincipalLicenseDetail.Definition(),
        new ServicePrincipalMemberOf.Definition(),
        new ServicePrincipalOauth2PermissionGrant.Definition(),
        new ServicePrincipalOwnedObject.Definition(),
        new ServicePrincipalOwner.Definition(),
        new ServicePrincipalSynchronization.Definition(),
        new ServicePrincipalSynchronizationJob.Definition(),
        new ServicePrincipalSynchronizationJobBulkUpload.Definition(),
        new ServicePrincipalSynchronizationJobSchema.Definition(),
        new ServicePrincipalSynchronizationJobSchemaDirectory.Definition(),
        new ServicePrincipalSynchronizationSecret.Definition(),
        new ServicePrincipalSynchronizationTemplate.Definition(),
        new ServicePrincipalSynchronizationTemplateSchema.Definition(),
        new ServicePrincipalSynchronizationTemplateSchemaDirectory.Definition(),
        new ServicePrincipalTokenIssuancePolicy.Definition(),
        new ServicePrincipalTokenLifetimePolicy.Definition(),
        new ServicePrincipalTransitiveMemberOf.Definition()
    };
}
