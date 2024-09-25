// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type Settings struct {
	// Whether model structs should have an `OmitDiscriminatedValue` field, to allow the caller to omit the
	// discriminated type value when marhalling. Used in Microsoft Graph for buggy APIs that don't parse this.
	AllowOmittingDiscriminatedValue bool

	// CanonicalApiVersions is a map of API version names to use in the SDK, where the key is the SDK-friendly
	// name, and the value is the upstream API version. Used in Microsoft Graph to translate `v1.0` to `stable`.
	CanonicalApiVersions map[string]string

	// CommonTypesPackageName is the name of the Go package that should be output with common models, constants
	// and resource IDs. Each API version will get a package below this containing the respective types. Used
	// in Microsoft Graph. Could be used in Resource Manager or other SDKs.
	CommonTypesPackageName string

	// DeleteExistingResourcesForVersion toggles whether any existing resources within a given API version should
	// be removed prior to generating. This is not compatible when more than one SourceDataType is being used to
	// generate an SDK. Used in Microsoft Graph because breaking removals are allowed.
	DeleteExistingResourcesForVersion bool

	// GenerateDescriptionsForModels enables nicely-formatted Go comments for model fields to be generated.
	GenerateDescriptionsForModels bool

	// RecurseParentModels is a behavioral toggle for discriminated types. When true, the full ancestry for child
	// models will be output in the SDK. When false, only the youngest ancestor containing the necessary type
	// information will be output. Used in Microsoft Graph to properly express model inheritance.
	RecurseParentModels bool

	// VersionsToGenerateCommonTypes is a map of API versions to SourceDataOrigin, to specify the API versions
	// for which common types should be generated. This is necessary because common types are enumerated separately
	// from service definitions. Used in Microsoft Graph.
	VersionsToGenerateCommonTypes map[string]models.SourceDataOrigin

	servicesUsingOldBaseLayer map[string]struct{}
}

func (s *Settings) CanonicalApiVersion(version string) *string {
	if v, ok := s.CanonicalApiVersions[version]; ok {
		return &v
	}
	return nil
}

func (s *Settings) UseOldBaseLayerFor(serviceNames ...string) {
	if s.servicesUsingOldBaseLayer == nil {
		s.servicesUsingOldBaseLayer = map[string]struct{}{}
	}
	for _, name := range serviceNames {
		s.servicesUsingOldBaseLayer[name] = struct{}{}
	}
}

func (s *Settings) ShouldUseNewBaseLayer(serviceName, version string) bool {
	if _, ok := s.servicesUsingOldBaseLayer[serviceName]; ok {
		return false
	}
	if _, ok := s.servicesUsingOldBaseLayer[fmt.Sprintf("%s@%s", serviceName, version)]; ok {
		return false
	}
	return true
}
