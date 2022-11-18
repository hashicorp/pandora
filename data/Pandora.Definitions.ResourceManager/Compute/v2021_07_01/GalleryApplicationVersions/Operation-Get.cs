using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryApplicationVersions;

internal class GetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ApplicationVersionId();

\t\tpublic override Type? ResponseObject() => typeof(GalleryApplicationVersionModel);

\t\tpublic override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ReplicationStatusTypesConstant Expand { get; set; }
    }
}
