package generator

import "fmt"

var _ templaterForResource = versionTemplater{}

type versionTemplater struct {
}

func (c versionTemplater) template(data GeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	apiVersion := data.apiVersion
	if data.canonicalApiVersion != nil {
		apiVersion = *data.canonicalApiVersion
	}

	template := fmt.Sprintf(`package %[1]s

import "fmt"

%[4]s

const defaultApiVersion = "%[2]s"

func userAgent() string {
	return "hashicorp/go-azure-sdk/%[1]s/%[3]s"
}
`, data.packageName, apiVersion, data.apiVersion, *copyrightLines)
	return &template, nil
}
