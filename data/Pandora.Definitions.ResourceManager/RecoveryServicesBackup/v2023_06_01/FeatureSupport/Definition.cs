using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.FeatureSupport;

internal class Definition : ResourceDefinition
{
    public string Name => "FeatureSupport";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SupportStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupGoalFeatureSupportRequestModel),
        typeof(AzureVMResourceFeatureSupportRequestModel),
        typeof(AzureVMResourceFeatureSupportResponseModel),
        typeof(FeatureSupportRequestModel),
    };
}
