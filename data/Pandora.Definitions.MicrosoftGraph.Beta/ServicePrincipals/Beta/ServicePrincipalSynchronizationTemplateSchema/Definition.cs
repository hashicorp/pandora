// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationTemplateSchema;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalSynchronizationTemplateSchema";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteServicePrincipalByIdSynchronizationTemplateByIdSchemaOperation(),
        new GetServicePrincipalByIdSynchronizationTemplateByIdSchemaOperation(),
        new ParseServicePrincipalByIdSynchronizationTemplateByIdSchemaExpressionOperation(),
        new UpdateServicePrincipalByIdSynchronizationTemplateByIdSchemaOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ParseServicePrincipalByIdSynchronizationTemplateByIdSchemaExpressionRequestModel)
    };
}
