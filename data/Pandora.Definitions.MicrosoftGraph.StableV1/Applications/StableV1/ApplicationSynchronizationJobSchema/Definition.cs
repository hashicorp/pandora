// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationJobSchema;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationSynchronizationJobSchema";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeleteSchemaOperation(),
        new GetSchemaOperation(),
        new ParseSchemaExpressionOperation(),
        new UpdateSchemaOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ParseSchemaExpressionRequestModel)
    };
}
