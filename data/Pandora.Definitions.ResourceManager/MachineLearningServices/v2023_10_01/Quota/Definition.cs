using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.Quota;

internal class Definition : ResourceDefinition
{
    public string Name => "Quota";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(QuotaUnitConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(QuotaBasePropertiesModel),
        typeof(QuotaUpdateParametersModel),
        typeof(ResourceNameModel),
        typeof(ResourceQuotaModel),
        typeof(UpdateWorkspaceQuotasModel),
        typeof(UpdateWorkspaceQuotasResultModel),
    };
}
