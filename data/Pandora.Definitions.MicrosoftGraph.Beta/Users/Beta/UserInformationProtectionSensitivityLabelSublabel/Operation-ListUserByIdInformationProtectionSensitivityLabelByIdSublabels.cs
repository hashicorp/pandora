// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserInformationProtectionSensitivityLabelSublabel;

internal class ListUserByIdInformationProtectionSensitivityLabelByIdSublabelsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdInformationProtectionSensitivityLabelId();
    public override Type NestedItemType() => typeof(SensitivityLabelCollectionResponseModel);
    public override string? UriSuffix() => "/sublabels";
}
