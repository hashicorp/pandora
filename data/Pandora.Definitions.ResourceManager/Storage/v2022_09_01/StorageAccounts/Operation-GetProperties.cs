using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.StorageAccounts;

internal class GetPropertiesOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new StorageAccountId();

    public override Type? ResponseObject() => typeof(StorageAccountModel);

    public override Type? OptionsObject() => typeof(GetPropertiesOperation.GetPropertiesOptions);

    internal class GetPropertiesOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public StorageAccountExpandConstant Expand { get; set; }
    }
}
