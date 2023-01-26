using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ServiceTags;

internal class ServiceTagInformationListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LocationId();

    public override Type NestedItemType() => typeof(ServiceTagInformationModel);

    public override Type? OptionsObject() => typeof(ServiceTagInformationListOperation.ServiceTagInformationListOptions);

    public override string? UriSuffix() => "/serviceTagDetails";

    internal class ServiceTagInformationListOptions
    {
        [QueryStringName("noAddressPrefixes")]
        [Optional]
        public bool NoAddressPrefixes { get; set; }

        [QueryStringName("tagName")]
        [Optional]
        public string TagName { get; set; }
    }
}
