package generator

import (
	"strings"
	"testing"
)

func TestVersionTemplater(t *testing.T) {
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
	if !strings.EqualFold(strings.TrimSpace(*actual), strings.TrimSpace(expected)) {
		t.Fatalf("Expected:\n\n---\n%s\n---\nActual:\n%s", expected, *actual)
	}
}
