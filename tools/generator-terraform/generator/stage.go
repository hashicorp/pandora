package generator

type stage interface {
	applicable(data *Data) bool
	filePath(data Data) string
	generate(data Data) (*string, error)
}
