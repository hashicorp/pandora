using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.GET;

internal class TasksGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new TaskId();

    public override Type? ResponseObject() => typeof(ProjectTaskModel);

    public override Type? OptionsObject() => typeof(TasksGetOperation.TasksGetOptions);

    internal class TasksGetOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
