// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"testing"
)

func TestTemplateClient(t *testing.T) {
	input := GeneratorData{
		baseClientPackage: "testclient",
		packageName:       "somepackage",
		serviceClientName: "ExampleClient",
		source:            AccTestLicenceType,
	}

	actual, err := clientsTemplater{}.template(input)
	if err != nil {
		t.Fatal(err.Error())
	}

	expected := `package somepackage

import (
	"fmt"
	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
)

// acctests licence placeholder

type ExampleClient struct {
	Client  *testclient.Client
}

func NewExampleClientWithBaseURI(sdkApi sdkEnv.Api) (*ExampleClient, error) {
	client, err := testclient.NewClient(sdkApi, "somepackage", defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating ExampleClient: %+v", err)
	}

	return &ExampleClient{
		Client: client,
	}, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
