using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.TagRules;

internal class Definition : ResourceDefinition
{
    public string Name => "TagRules";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new SubAccountTagRulesCreateOrUpdateOperation(),
        new SubAccountTagRulesDeleteOperation(),
        new SubAccountTagRulesGetOperation(),
        new SubAccountTagRulesListOperation(),
    };
}
