using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.GlobalRulestack;

internal class ListAppIdsOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new GlobalRulestackId();

    public override Type? ResponseObject() => typeof(ListAppIdResponseModel);

    public override Type? OptionsObject() => typeof(ListAppIdsOperation.ListAppIdsOptions);

    public override string? UriSuffix() => "/listAppIds";

    internal class ListAppIdsOptions
    {
        [QueryStringName("appIdVersion")]
        [Optional]
        public string AppIdVersion { get; set; }

        [QueryStringName("appPrefix")]
        [Optional]
        public string AppPrefix { get; set; }

        [QueryStringName("skip")]
        [Optional]
        public string Skip { get; set; }

        [QueryStringName("top")]
        [Optional]
        public int Top { get; set; }
    }
}
