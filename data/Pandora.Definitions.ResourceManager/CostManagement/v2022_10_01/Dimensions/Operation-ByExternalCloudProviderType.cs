using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Dimensions;

internal class ByExternalCloudProviderTypeOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ExternalCloudProviderTypeId();

\t\tpublic override Type? ResponseObject() => typeof(DimensionModel);

\t\tpublic override Type? OptionsObject() => typeof(ByExternalCloudProviderTypeOperation.ByExternalCloudProviderTypeOptions);

\t\tpublic override string? UriSuffix() => "/dimensions";

    internal class ByExternalCloudProviderTypeOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }

        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
