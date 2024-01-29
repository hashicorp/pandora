// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.Interfaces;

/// <summary>
/// ServicesDefinition is used to locate ServiceDefinitions nested in the namespace under this ServicesDefinition
/// Example: `ResourceManagerServices` (ServicesDefinition) contains `ResourcesService` which contains
/// `v2020_01_01` (ApiVersionDefinition)
/// </summary>
public interface ServicesDefinition
{

}