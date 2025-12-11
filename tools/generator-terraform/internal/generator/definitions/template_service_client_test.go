// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestTemplateForServiceClient(t *testing.T) {
	input := models.ServiceInput{
		ProviderPrefix: "myprovider", // intentionally not used, since this is `client`
		ResourceToApiVersion: map[string]string{
			"resources_resource": "2015-11-01-preview",
		},
		SdkServiceName:     "resources",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceClient(input)
	expected := `
package client

import (
	resourcesV20151101Preview "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2015-11-01-preview"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type AutoClient struct {
	V20151101Preview resourcesV20151101Preview.Client
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	v20151101PreviewClient, err := resourcesV20151101Preview.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for resources v20151101Preview: %+v", err)
	}
	return &AutoClient{
		V20151101Preview: *v20151101PreviewClient,
	}, nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestTemplateForServiceClient_WithMultipleApiVersions(t *testing.T) {
	input := models.ServiceInput{
		ProviderPrefix: "myprovider", // intentionally not used, since this is `client`
		ResourceToApiVersion: map[string]string{
			"resources_one_resource": "2015-11-01-preview",
			"resources_two_resource": "2020-01-01",
		},
		SdkServiceName:     "resources",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceClient(input)
	expected := `
package client

import (
	resourcesV20151101Preview "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2015-11-01-preview"
	resourcesV20200101 "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2020-01-01"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type AutoClient struct {
	V20151101Preview resourcesV20151101Preview.Client
	V20200101 resourcesV20200101.Client
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	v20151101PreviewClient, err := resourcesV20151101Preview.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for resources v20151101Preview: %+v", err)
	}
	v20200101Client, err := resourcesV20200101.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for resources v20200101: %+v", err)
	}
	return &AutoClient{
		V20151101Preview: *v20151101PreviewClient,
		V20200101: *v20200101Client,
	}, nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestTemplateForServiceClient_WithMultipleResourcesAndOneApiVersion(t *testing.T) {
	input := models.ServiceInput{
		ProviderPrefix: "myprovider", // intentionally not used, since this is `client`
		ResourceToApiVersion: map[string]string{
			"resources_one_resource": "2015-11-01-preview",
			"resources_two_resource": "2015-11-01-preview",
		},
		SdkServiceName:     "resources",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceClient(input)
	expected := `
package client

import (
	resourcesV20151101Preview "github.com/hashicorp/go-azure-sdk/resource-manager/resources/2015-11-01-preview"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/terraform-provider-myprovider/internal/common"
)

type AutoClient struct {
	V20151101Preview resourcesV20151101Preview.Client
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	v20151101PreviewClient, err := resourcesV20151101Preview.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
		o.Configure(c, o.Authorizers.ResourceManager)
	})
	if err != nil {
		return nil, fmt.Errorf("building client for resources v20151101Preview: %+v", err)
	}
	return &AutoClient{
		V20151101Preview: *v20151101PreviewClient,
	}, nil
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
