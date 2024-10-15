// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataworkarounds

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/combine"
)

var _ workaround = workaroundNetwork29303{}

// The swagger for PrivateLinkService in Network associates the CreateOrUpdate method with the tag
// `PrivateLinkService` instead of `PrivateLinkServices` like the rest of the operations do. This consolidates
// the two resources that Pandora identifies into one.
// Can be removed when https://github.com/Azure/azure-rest-api-specs/pull/29303 has been merged.
type workaroundNetwork29303 struct {
}

func (workaroundNetwork29303) IsApplicable(serviceName string, apiVersion sdkModels.APIVersion) bool {
	serviceMatches := serviceName == "Network"
	_, hasCorrectlyNamedAPIResource := apiVersion.Resources["PrivateLinkService"]
	_, hasMisnamedAPIResource := apiVersion.Resources["PrivateLinkServices"]
	return serviceMatches && hasCorrectlyNamedAPIResource && hasMisnamedAPIResource
}

func (workaroundNetwork29303) Name() string {
	return "Network / 29303"
}

func (workaroundNetwork29303) Process(input sdkModels.APIVersion) (*sdkModels.APIVersion, error) {
	correctlyNamedAPIResource, ok := input.Resources["PrivateLinkServices"]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource named `PrivateLinkServices` but didn't find one")
	}
	misnamedAPIResource, ok := input.Resources["PrivateLinkService"]
	if !ok {
		return nil, fmt.Errorf("expected an APIResource named `PrivateLinkService` but didn't find one")
	}

	combined, err := combine.APIResource(correctlyNamedAPIResource, misnamedAPIResource)
	if err != nil {
		return nil, fmt.Errorf("combining the APIResource `PrivateLinkServices`: %+v", err)
	}
	input.Resources["PrivateLinkServices"] = *combined
	delete(input.Resources, "PrivateLinkService")

	return &input, nil
}
