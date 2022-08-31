using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerInstance.v2021_10_01.ContainerInstance;

internal class ContainersListLogsOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ContainerId();

    public override Type? ResponseObject() => typeof(LogsModel);

    public override Type? OptionsObject() => typeof(ContainersListLogsOperation.ContainersListLogsOptions);

    public override string? UriSuffix() => "/logs";

    internal class ContainersListLogsOptions
    {
        [QueryStringName("tail")]
        [Optional]
        public int Tail { get; set; }

        [QueryStringName("timestamps")]
        [Optional]
        public bool Timestamps { get; set; }
    }
}
