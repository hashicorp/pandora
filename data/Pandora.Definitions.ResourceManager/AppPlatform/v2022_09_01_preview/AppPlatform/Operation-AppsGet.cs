using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppPlatform.v2022_09_01_preview.AppPlatform;

internal class AppsGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AppId();

\t\tpublic override Type? ResponseObject() => typeof(AppResourceModel);

\t\tpublic override Type? OptionsObject() => typeof(AppsGetOperation.AppsGetOptions);

    internal class AppsGetOptions
    {
        [QueryStringName("syncStatus")]
        [Optional]
        public string SyncStatus { get; set; }
    }
}
