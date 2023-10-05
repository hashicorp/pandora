using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.EnvironmentTypes;

internal class ProjectEnvironmentTypesListOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new ProjectId();

    public override Type NestedItemType() => typeof(ProjectEnvironmentTypeModel);

    public override Type? OptionsObject() => typeof(ProjectEnvironmentTypesListOperation.ProjectEnvironmentTypesListOptions);

    public override string? UriSuffix() => "/environmentTypes";

    internal class ProjectEnvironmentTypesListOptions
    {
        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
