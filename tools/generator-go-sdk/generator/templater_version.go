package generator

import "fmt"

var _ templater = versionTemplater{}

type versionTemplater struct {
}

func (c versionTemplater) template(data ServiceGeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	// TODO: when this is split into it's own repo make the UA `hashicorp/go-azure-sdk`
	template := fmt.Sprintf(`package %[1]s

import "fmt"

%[3]s

const defaultApiVersion = "%[2]s"

func userAgent() string {
	return fmt.Sprintf("pandora/%[1]s/%%s", defaultApiVersion)
}
`, data.packageName, data.apiVersion, *copyrightLines)
	return &template, nil
}
