using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2023_05_01.ExtensionOperationStatus;

internal class Definition : ResourceDefinition
{
    public string Name => "ExtensionOperationStatus";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new OperationStatusGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(OperationStatusResultModel),
    };
}
