// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeInferenceClassificationOverride;

internal class Definition : ResourceDefinition
{
    public string Name => "MeInferenceClassificationOverride";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeInferenceClassificationOverrideOperation(),
        new DeleteMeInferenceClassificationOverrideByIdOperation(),
        new GetMeInferenceClassificationOverrideByIdOperation(),
        new GetMeInferenceClassificationOverrideCountOperation(),
        new ListMeInferenceClassificationOverridesOperation(),
        new UpdateMeInferenceClassificationOverrideByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
