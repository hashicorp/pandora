// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDeviceSecurityBaselineStateSettingState;

internal class CreateUserByIdManagedDeviceByIdSecurityBaselineStateByIdSettingStateOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(SecurityBaselineSettingStateModel);
    public override ResourceID? ResourceId() => new UserIdManagedDeviceIdSecurityBaselineStateId();
    public override Type? ResponseObject() => typeof(SecurityBaselineSettingStateModel);
    public override string? UriSuffix() => "/settingStates";
}
