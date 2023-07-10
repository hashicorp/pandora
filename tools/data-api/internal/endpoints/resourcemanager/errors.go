package resourcemanager

import (
	"log"
	"net/http"
)

func internalServerError(w http.ResponseWriter, err error) {
	log.Printf("[ERROR] %+v", err)
	http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
}
