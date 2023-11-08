using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.RunbookDraft;

internal class Definition : ResourceDefinition
{
    public string Name => "RunbookDraft";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetContentOperation(),
        new ReplaceContentOperation(),
        new UndoEditOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HTTPStatusCodeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentLinkModel),
        typeof(RunbookDraftModel),
        typeof(RunbookDraftUndoEditResultModel),
        typeof(RunbookParameterModel),
    };
}
