using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;

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
