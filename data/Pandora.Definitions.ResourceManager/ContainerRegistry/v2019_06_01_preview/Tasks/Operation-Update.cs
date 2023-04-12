using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Tasks;

internal class UpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(TaskUpdateParametersModel);

    public override ResourceID? ResourceId() => new TaskId();

    public override Type? ResponseObject() => typeof(TaskModel);


}
