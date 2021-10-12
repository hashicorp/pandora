package featureflags

// ShouldOutputResourceIdsToFile specifies whether a List of Sorted (but not Unique) Resource ID's
// should be output to a file named `resource-ids.txt` when the import is run.
//
// This allows these ID's to be parsed to pull out the individual segment names, for example
// to ensure these are all normalized (see `NormalizeSegment` in ./cleanup/normalizer.go).
const ShouldOutputResourceIdsToFile = false
