using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.ResourceGroups;

internal class DeleteOperation : Operations.DeleteOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type? OptionsObject() => typeof(DeleteOperation.DeleteOptions);

    internal class DeleteOptions
    {
        [QueryStringName("forceDeletionTypes")]
        [Optional]
        public string ForceDeletionTypes { get; set; }
    }
}
