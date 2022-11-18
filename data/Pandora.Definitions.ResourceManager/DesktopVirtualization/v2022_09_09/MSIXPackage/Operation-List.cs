using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.MSIXPackage;

internal class ListOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new HostPoolId();

\t\tpublic override Type NestedItemType() => typeof(MSIXPackageModel);

\t\tpublic override Type? OptionsObject() => typeof(ListOperation.ListOptions);

\t\tpublic override string? UriSuffix() => "/msixPackages";

    internal class ListOptions
    {
        [QueryStringName("initialSkip")]
        [Optional]
        public int InitialSkip { get; set; }

        [QueryStringName("isDescending")]
        [Optional]
        public bool IsDescending { get; set; }

        [QueryStringName("pageSize")]
        [Optional]
        public int PageSize { get; set; }
    }
}
