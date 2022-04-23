package generator

import (
	"testing"
)

func TestTemplateVersion(t *testing.T) {
	input := ServiceGeneratorData{
		packageName: "somepackage",
		apiVersion:  "2022-02-01",
	}

	actual, err := versionTemplater{}.template(input)
	if err != nil {
		t.Fatal(err.Error())
	}

	expected := `package somepackage

import "fmt"

const defaultApiVersion = "2022-02-01"

func userAgent() string {
	return fmt.Sprintf("pandora/somepackage/%s", defaultApiVersion)
}`
	assertTemplatedCodeMatches(t, *actual, expected)
}
