package generator

import "fmt"

var _ templaterForResource = versionTemplater{}

type versionTemplater struct {
}

func (c versionTemplater) template(data ServiceGeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	template := fmt.Sprintf(`package %[2]s

import "fmt"

%[4]s

const defaultApiVersion = "%[3]s"

func userAgent() string {
	return fmt.Sprintf("hashicorp/go-azure-sdk/%[1]s/%[2]s/%%s", defaultApiVersion)
}
`, data.baseClientPackage, data.packageName, data.apiVersion, *copyrightLines)
	return &template, nil
}
