package services

type Config struct {
	// Services is a slice of Services which should be imported
	Services []Service `hcl:"service,block"`
}

type Service struct {
	// Directory is the name of the Swagger directory for this Service (e.g. appconfiguration)
	Directory string `hcl:"directory,label"`

	// Name is the normalized (title-case, no spaces etc) name for this Service (e.g. AppConfiguration)
	Name string `hcl:"name"`

	// Available is a list of the Versions for this Service which should be imported
	Available []string `hcl:"available"`

	// Ignore is a list of Versions which should be Ignored for this Service
	// A version is automatically ignored if it's not defined in
	Ignore *[]string `hcl:"ignore"`
}
