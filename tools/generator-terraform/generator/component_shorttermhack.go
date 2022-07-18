package generator

import "fmt"

func methodsYetToBeImplementedForResource(input ResourceInput) string {
	return fmt.Sprintf(`
// TODO: the methods below this point are yet to be implemented
// but are output purely to keep the compiler for happy in the short-term
// by ensuring that this Resource correctly implements 'sdk.Resource'

func (r %[1]sResource) Attributes() map[string]*pluginsdk.Schema {
	return map[string]*pluginsdk.Schema{}
}

func (r %[1]sResource) Arguments() map[string]*pluginsdk.Schema {
	return map[string]*pluginsdk.Schema{}
}

func (r %[1]sResource) ModelObject() interface{} {
	// TODO: implement me in the generator
	return &%[1]sResourceModel{}
}

type %[1]sResourceModel struct {
	// TODO: this is purely a placeholder to make it compile for now
}
`, input.ResourceTypeName)
}
