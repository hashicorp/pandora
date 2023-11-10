using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_08_01.DppFeatureSupport;

internal class Definition : ResourceDefinition
{
    public string Name => "DppFeatureSupport";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DataProtectionCheckFeatureSupportOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FeatureSupportStatusConstant),
        typeof(FeatureTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FeatureValidationRequestModel),
        typeof(FeatureValidationRequestBaseModel),
        typeof(FeatureValidationResponseModel),
        typeof(FeatureValidationResponseBaseModel),
        typeof(SupportedFeatureModel),
    };
}
