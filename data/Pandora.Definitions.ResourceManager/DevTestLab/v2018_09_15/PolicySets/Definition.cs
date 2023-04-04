using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.PolicySets;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicySets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EvaluatePoliciesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EvaluatePoliciesPropertiesModel),
        typeof(EvaluatePoliciesRequestModel),
        typeof(EvaluatePoliciesResponseModel),
        typeof(PolicySetResultModel),
        typeof(PolicyViolationModel),
    };
}
