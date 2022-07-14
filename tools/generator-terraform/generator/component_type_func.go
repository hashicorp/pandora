package generator

import "fmt"

func typeFuncForResource(input ResourceInput) string {
	return fmt.Sprintf(`
func (r %[1]sResource) ResourceType() string {
	return "%[2]s_%[3]s"
}
`, input.ResourceTypeName, input.ProviderPrefix, input.ResourceLabel)
}
