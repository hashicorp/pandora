using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(RecordSetModel);

    public override ResourceID? ResourceId() => new RecordTypeId();

    public override Type? ResponseObject() => typeof(RecordSetModel);

    public override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    internal class CreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfNegativeMatch { get; set; }

        [HeaderName("If-None-Match")]
        [Optional]
        public string IfNegativeNoneNegativeMatch { get; set; }
    }
}
