using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Schema;

internal class GlobalSchemaCreateOrUpdateOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(GlobalSchemaContractModel);

\t\tpublic override ResourceID? ResourceId() => new SchemaId();

\t\tpublic override Type? ResponseObject() => typeof(GlobalSchemaContractModel);

\t\tpublic override Type? OptionsObject() => typeof(GlobalSchemaCreateOrUpdateOperation.GlobalSchemaCreateOrUpdateOptions);

    internal class GlobalSchemaCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
