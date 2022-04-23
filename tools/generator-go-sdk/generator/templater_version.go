package generator

import "fmt"

var _ templater = versionTemplater{}

type versionTemplater struct {
}

func (c versionTemplater) template(data ServiceGeneratorData) (*string, error) {
	// TODO: when this is split into it's own repo make the UA `hashicorp/go-azure-sdk`
	template := fmt.Sprintf(`package %[1]s

import "fmt"

const defaultApiVersion = "%[2]s"

func userAgent() string {
	return fmt.Sprintf("pandora/%[1]s/%%s", defaultApiVersion)
}
`, data.packageName, data.apiVersion)
	return &template, nil
}
