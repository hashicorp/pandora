using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.LiveOutputs;

internal class Definition : ResourceDefinition
{
    public string Name => "LiveOutputs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AsyncOperationOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new OperationLocationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AsyncOperationStatusConstant),
        typeof(LiveOutputResourceStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsyncOperationResultModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(HlsModel),
        typeof(LiveOutputModel),
        typeof(LiveOutputPropertiesModel),
    };
}
