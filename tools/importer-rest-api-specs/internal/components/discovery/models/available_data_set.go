package models

type AvailableDataSet struct {
	// TODO: docs
	ServiceName            string
	DataSetsForAPIVersions map[string]AvailableDataSetForAPIVersion
	ResourceProvider       *string
}

type AvailableDataSetForAPIVersion struct {
	// APIVersion specifies the APIVersion which this DataSet is related to.
	APIVersion string

	// FilePathsContainingAPIDefinitions is a slice of the absolute file paths which contain the APIDefinitions
	// for the Service/API Version combination.
	FilePathsContainingAPIDefinitions []string

	// FilePathsContainingSupplementaryData is a slice of the absolute file paths which contain supplementary data
	// related to the APIDefinitions for the Service/API Version combination. These should be parsed prior to
	// parsing the files within FilePathsContainingAPIDefinitions - and typically contain Discriminated Models.
	FilePathsContainingSupplementaryData []string
}
