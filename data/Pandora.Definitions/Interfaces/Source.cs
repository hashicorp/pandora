// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.Interfaces;

public enum Source
{
    /// <summary>
    /// Unknown is an invalid value, it's only present to catch the default case
    /// </summary>
    Unknown = 0,

    /// <summary>
    /// HandWritten specifies that this set of API Definitions was written by hand
    /// </summary>
    HandWritten,

    /// <summary>
    /// ResourceManagerRestApiSpecs specifies that this set of API Definitions
    /// is sourced from data within the github.com/Azure/azure-rest-api-specs repository
    /// </summary>
    ResourceManagerRestApiSpecs,

    /// <summary>
    /// MicrosoftGraphMetadata specifies that this set of API Definitions
    /// is sourced from data within the github.com/microsoftgraph/msgraph-metadata repository
    /// </summary>
    MicrosoftGraphMetadata,
}