using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.RegulatoryCompliance;

internal class AssessmentsListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new RegulatoryComplianceControlId();

    public override Type NestedItemType() => typeof(RegulatoryComplianceAssessmentModel);

    public override Type? OptionsObject() => typeof(AssessmentsListOperation.AssessmentsListOptions);

    public override string? UriSuffix() => "/regulatoryComplianceAssessments";

    internal class AssessmentsListOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }
    }
}
