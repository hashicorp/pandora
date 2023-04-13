using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.ServiceResource;

internal class TasksListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ProjectId();

    public override Type NestedItemType() => typeof(ProjectTaskModel);

    public override Type? OptionsObject() => typeof(TasksListOperation.TasksListOptions);

    public override string? UriSuffix() => "/tasks";

    internal class TasksListOptions
    {
        [QueryStringName("taskType")]
        [Optional]
        public string TaskType { get; set; }
    }
}
