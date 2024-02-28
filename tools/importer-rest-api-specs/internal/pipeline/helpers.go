package pipeline

import (
	"fmt"

	"github.com/go-git/go-git/v5"
	"github.com/hashicorp/go-hclog"
)

func determineGitSha(repositoryPath string, logger hclog.Logger) (*string, error) {
	repo, err := git.PlainOpen(repositoryPath)
	if err != nil {
		return nil, err
	}

	ref, err := repo.Head()
	if err != nil {
		return nil, err
	}

	commit := ref.Hash().String()
	logger.Debug(fmt.Sprintf("Swagger Repository Commit SHA is %q", commit))
	return &commit, nil
}
