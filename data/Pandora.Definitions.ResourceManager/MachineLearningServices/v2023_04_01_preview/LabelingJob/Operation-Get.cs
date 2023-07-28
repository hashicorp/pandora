using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.LabelingJob;

internal class GetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LabelingJobId();

    public override Type? ResponseObject() => typeof(LabelingJobResourceModel);

    public override Type? OptionsObject() => typeof(GetOperation.GetOptions);

    internal class GetOptions
    {
        [QueryStringName("includeJobInstructions")]
        [Optional]
        public bool IncludeJobInstructions { get; set; }

        [QueryStringName("includeLabelCategories")]
        [Optional]
        public bool IncludeLabelCategories { get; set; }
    }
}
