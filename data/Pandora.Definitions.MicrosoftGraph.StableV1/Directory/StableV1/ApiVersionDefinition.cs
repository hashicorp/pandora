// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "StableV1";
    public bool Preview => false;
    public Source Source => Source.MicrosoftGraphMetadata;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Directory.Definition(),
        new DirectoryAdministrativeUnit.Definition(),
        new DirectoryAdministrativeUnitExtension.Definition(),
        new DirectoryAdministrativeUnitMember.Definition(),
        new DirectoryAdministrativeUnitScopedRoleMember.Definition(),
        new DirectoryAttributeSet.Definition(),
        new DirectoryCustomSecurityAttributeDefinition.Definition(),
        new DirectoryCustomSecurityAttributeDefinitionAllowedValue.Definition(),
        new DirectoryDeletedItem.Definition(),
        new DirectoryFederationConfiguration.Definition(),
        new DirectoryOnPremisesSynchronization.Definition()
    };
}
