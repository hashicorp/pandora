// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestCodeForClientRegistrationsEmpty(t *testing.T) {
	input := models.ServicesInput{
		ProviderPrefix: "myprovider",
		Services:       map[string]models.ServiceInput{},
	}
	actual := codeForClientsRegistration(input)
	expected := `
package clients

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"context"

	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type autoClient struct {
}

func buildAutoClients(client *autoClient, o *common.ClientOptions) (err error) {
	return nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestCodeForClientRegistrations(t *testing.T) {
	input := models.ServicesInput{
		ProviderPrefix: "myprovider",
		Services: map[string]models.ServiceInput{
			"Compute": {
				ResourceToApiVersion: map[string]string{
					"compute_resource": "2020-01-01",
				},
				SdkServiceName:     "Compute",
				ServicePackageName: "compute",
			},
			"Resource": {
				ResourceToApiVersion: map[string]string{
					"resources_resource": "2015-11-01-preview",
				},
				SdkServiceName:     "Resources",
				ServicePackageName: "resources",
			},
		},
	}
	actual := codeForClientsRegistration(input)
	expected := `
package clients

// NOTE: this file is generated - manual changes will be overwritten.

import (
	"context"

	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
	compute "github.com/hashicorp/terraform-provider-myprovider/internal/services/compute/client"
	resources "github.com/hashicorp/terraform-provider-myprovider/internal/services/resources/client"
)

type autoClient struct {
	Compute   *compute.AutoClient
	Resource   *resources.AutoClient
}

func buildAutoClients(client *autoClient, o *common.ClientOptions) (err error) {
	if client.Compute, err = compute.NewClient(o); err != nil {
		return fmt.Errorf("building client for Compute: %+v", err)
	}
	if client.Resource, err = resources.NewClient(o); err != nil {
		return fmt.Errorf("building client for Resource: %+v", err)
	}
	return nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
