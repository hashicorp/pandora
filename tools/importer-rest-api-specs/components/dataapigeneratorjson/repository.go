package dataapigeneratorjson

// Repository is an interface defining how to load and save API Definitions from disk.
// This interface is designed to allow the implementation to be switched out for testing purposes if needed.
type Repository interface {
	// SaveService persists the API Definitions for the Service specified in opts.
	SaveService(opts SaveServiceOptions) error

	// TODO: RemoveService
	// TODO: LoadService
	// TODO: LoadServices
}

// NewRepository returns an instance of Repository configured for the working directory.
func NewRepository(workingDirectory string) Repository {
	return repositoryImpl{
		workingDirectory: workingDirectory,
	}
}

var _ Repository = &repositoryImpl{}

type repositoryImpl struct {
	// workingDirectory specifies the directory where the API Definitions exist/should be written to.
	// This is the path to the `./api-definitions` directory.
	workingDirectory string
}
