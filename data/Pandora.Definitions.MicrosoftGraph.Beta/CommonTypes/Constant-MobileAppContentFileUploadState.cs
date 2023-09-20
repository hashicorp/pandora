// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MobileAppContentFileUploadStateConstant
{
    [Description("Success")]
    @success,

    [Description("TransientError")]
    @transientError,

    [Description("Error")]
    @error,

    [Description("Unknown")]
    @unknown,

    [Description("AzureStorageUriRequestSuccess")]
    @azureStorageUriRequestSuccess,

    [Description("AzureStorageUriRequestPending")]
    @azureStorageUriRequestPending,

    [Description("AzureStorageUriRequestFailed")]
    @azureStorageUriRequestFailed,

    [Description("AzureStorageUriRequestTimedOut")]
    @azureStorageUriRequestTimedOut,

    [Description("AzureStorageUriRenewalSuccess")]
    @azureStorageUriRenewalSuccess,

    [Description("AzureStorageUriRenewalPending")]
    @azureStorageUriRenewalPending,

    [Description("AzureStorageUriRenewalFailed")]
    @azureStorageUriRenewalFailed,

    [Description("AzureStorageUriRenewalTimedOut")]
    @azureStorageUriRenewalTimedOut,

    [Description("CommitFileSuccess")]
    @commitFileSuccess,

    [Description("CommitFilePending")]
    @commitFilePending,

    [Description("CommitFileFailed")]
    @commitFileFailed,

    [Description("CommitFileTimedOut")]
    @commitFileTimedOut,
}
