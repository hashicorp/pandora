using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2019_10_17_preview.AsyncOperations;

internal class Definition : ResourceDefinition
{
    public string Name => "AsyncOperations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PrivateLinkScopeOperationStatusGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorResponseCommonModel),
        typeof(OperationStatusModel),
    };
}
