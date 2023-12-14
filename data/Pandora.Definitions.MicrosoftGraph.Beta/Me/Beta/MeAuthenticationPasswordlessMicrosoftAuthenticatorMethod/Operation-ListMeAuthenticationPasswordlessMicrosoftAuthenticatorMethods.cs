// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAuthenticationPasswordlessMicrosoftAuthenticatorMethod;

internal class ListMeAuthenticationPasswordlessMicrosoftAuthenticatorMethodsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => null;
    public override Type NestedItemType() => typeof(PasswordlessMicrosoftAuthenticatorAuthenticationMethodCollectionResponseModel);
    public override string? UriSuffix() => "/me/authentication/passwordlessMicrosoftAuthenticatorMethods";
}
