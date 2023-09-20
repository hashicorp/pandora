// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserManagedDeviceDeviceConfigurationState;

internal class ListUserByIdManagedDeviceByIdDeviceConfigurationStatesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdManagedDeviceId();
    public override Type NestedItemType() => typeof(DeviceConfigurationStateCollectionResponseModel);
    public override string? UriSuffix() => "/deviceConfigurationStates";
}
