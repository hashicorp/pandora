using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.FileShares;

internal class CreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(FileShareModel);

    public override ResourceID? ResourceId() => new ShareId();

    public override Type? ResponseObject() => typeof(FileShareModel);

    public override Type? OptionsObject() => typeof(CreateOperation.CreateOptions);

    internal class CreateOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
