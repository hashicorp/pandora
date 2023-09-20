// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Applications.Beta;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "Beta";
    public bool Preview => true;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Application.Definition(),
        new ApplicationAppManagementPolicy.Definition(),
        new ApplicationConnectorGroup.Definition(),
        new ApplicationCreatedOnBehalfOf.Definition(),
        new ApplicationExtensionProperty.Definition(),
        new ApplicationFederatedIdentityCredential.Definition(),
        new ApplicationHomeRealmDiscoveryPolicy.Definition(),
        new ApplicationLogo.Definition(),
        new ApplicationOwner.Definition(),
        new ApplicationSynchronization.Definition(),
        new ApplicationSynchronizationJob.Definition(),
        new ApplicationSynchronizationJobBulkUpload.Definition(),
        new ApplicationSynchronizationJobSchema.Definition(),
        new ApplicationSynchronizationJobSchemaDirectory.Definition(),
        new ApplicationSynchronizationSecret.Definition(),
        new ApplicationSynchronizationTemplate.Definition(),
        new ApplicationSynchronizationTemplateSchema.Definition(),
        new ApplicationSynchronizationTemplateSchemaDirectory.Definition(),
        new ApplicationTokenIssuancePolicy.Definition(),
        new ApplicationTokenLifetimePolicy.Definition()
    };
}
