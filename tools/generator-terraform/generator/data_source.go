package generator

import "log"

type DataSourceInput struct {
	ProviderPrefix     string
	ResourceLabel      string
	RootDirectory      string
	ServicePackageName string
}

func DataSource(input DataSourceInput) error {
	// TODO: conditionally output both a Singular and Plural Data Source?
	log.Printf("TODO: Data Source stuff")
	return nil
}
