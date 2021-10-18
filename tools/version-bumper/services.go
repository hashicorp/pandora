package main

type ServiceLocator interface {
	AvailableServices() (*[]AvailableService, error)
}

type AvailableService struct {
	Name      string
	Directory string
	Version   []string
}
