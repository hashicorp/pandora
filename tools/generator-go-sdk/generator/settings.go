package generator

type Settings struct {
	Transport TransportLayer
}

type TransportLayer string

const (
	AutoRest TransportLayer = "autorest"
	Pandora  TransportLayer = "pandora"
)
