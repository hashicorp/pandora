// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMailFolderChildFolderMessageRule;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolderChildFolderMessageRule";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdChildFolderByIdMessageRuleOperation(),
        new DeleteMeMailFolderByIdChildFolderByIdMessageRuleByIdOperation(),
        new GetMeMailFolderByIdChildFolderByIdMessageRuleByIdOperation(),
        new GetMeMailFolderByIdChildFolderByIdMessageRuleCountOperation(),
        new ListMeMailFolderByIdChildFolderByIdMessageRulesOperation(),
        new UpdateMeMailFolderByIdChildFolderByIdMessageRuleByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
