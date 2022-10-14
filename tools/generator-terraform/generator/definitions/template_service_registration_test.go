package definitions

import (
	"testing"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

func TestTemplateForServiceRegistrationEmpty(t *testing.T) {
	input := models.ServiceInput{
		CategoryNames:      []string{},
		DataSourceNames:    []string{},
		ProviderPrefix:     "myprovider",
		ResourceNames:      []string{},
		ServiceDisplayName: "Awesome Service",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceRegistration(input)
	expected := `
package mypackage

// NOTE: this file is generated - manual changes will be overwritten.

import "github.com/hashicorp/terraform-provider-myprovider/internal/sdk"

var _ sdk.TypedServiceRegistration = autoRegistration{}

type autoRegistration struct {
}

func (autoRegistration) Name() string {
	return "Awesome Service"
}

func (autoRegistration) DataSources() []sdk.DataSource {
	return []sdk.DataSource{
	}
}

func (autoRegistration) Resources() []sdk.Resource {
	return []sdk.Resource{
	}
}

func (autoRegistration) WebsiteCategories() []string {
	return []string{
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}

func TestTemplateForServiceRegistration(t *testing.T) {
	input := models.ServiceInput{
		CategoryNames: []string{
			"Category3",
			"Category1",
		},
		DataSourceNames: []string{
			// intentional to check ordering
			"Example2",
			"Example3",
			"Example1",
		},
		ProviderPrefix: "myprovider",
		ResourceNames: []string{
			// intentional to check ordering
			"Third",
			"Second",
			"First",
		},
		ServiceDisplayName: "Awesome Service",
		ServicePackageName: "mypackage",
	}
	actual := templateForServiceRegistration(input)
	expected := `
package mypackage

// NOTE: this file is generated - manual changes will be overwritten.

import "github.com/hashicorp/terraform-provider-myprovider/internal/sdk"

var _ sdk.TypedServiceRegistration = autoRegistration{}

type autoRegistration struct {
}

func (autoRegistration) Name() string {
	return "Awesome Service"
}

func (autoRegistration) DataSources() []sdk.DataSource {
	return []sdk.DataSource{
		Example1DataSource{},
		Example2DataSource{},
		Example3DataSource{},
	}
}

func (autoRegistration) Resources() []sdk.Resource {
	return []sdk.Resource{
		FirstResource{},
		SecondResource{},
		ThirdResource{},
	}
}

func (autoRegistration) WebsiteCategories() []string {
	return []string{
		"Category1",
		"Category3",
	}
}
`
	testhelpers.AssertTemplatedCodeMatches(t, expected, actual)
}
