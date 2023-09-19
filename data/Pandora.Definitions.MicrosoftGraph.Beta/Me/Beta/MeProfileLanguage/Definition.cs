// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeProfileLanguage;

internal class Definition : ResourceDefinition
{
    public string Name => "MeProfileLanguage";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeProfileLanguageOperation(),
        new DeleteMeProfileLanguageByIdOperation(),
        new GetMeProfileLanguageByIdOperation(),
        new GetMeProfileLanguageCountOperation(),
        new ListMeProfileLanguagesOperation(),
        new UpdateMeProfileLanguageByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
