// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosManagedAppProtectionAllowedDataStorageLocationsConstant
{
    [Description("OneDriveForBusiness")]
    @oneDriveForBusiness,

    [Description("SharePoint")]
    @sharePoint,

    [Description("Box")]
    @box,

    [Description("LocalStorage")]
    @localStorage,

    [Description("PhotoLibrary")]
    @photoLibrary,
}
