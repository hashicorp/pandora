using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataContainerRegistry;

internal class RegistryDataContainersListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new RegistryId();

    public override Type NestedItemType() => typeof(DataContainerResourceModel);

    public override Type? OptionsObject() => typeof(RegistryDataContainersListOperation.RegistryDataContainersListOptions);

    public override string? UriSuffix() => "/data";

    internal class RegistryDataContainersListOptions
    {
        [QueryStringName("listViewType")]
        [Optional]
        public ListViewTypeConstant ListViewType { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
