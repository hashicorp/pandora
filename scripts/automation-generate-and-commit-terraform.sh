#!/bin/bash

set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
  echo "Outputting Go Version.."
  go version

  echo "Installing the Data API into the GOBIN.."
  cd "${DIR}/tools/data-api"
  go install .
  cd "${DIR}"

  echo "Installing the Terraform Generator into the GOBIN.."
  cd "${DIR}/tools/generator-terraform"
  go install .
  cd "${DIR}"

  echo "Building Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  go build -o wrapper-automation
  cd "${DIR}"
}

function runWrapper {
  local apiDefinitionsDirectory=$1
  local outputDirectory=$2

  echo "Running Wrapper.."
  cd "${DIR}/tools/wrapper-automation"
  ./wrapper-automation terraform \
    --api-definitions-dir="../../$apiDefinitionsDirectory"\
    --output-dir="../../$outputDirectory"

  cd "${DIR}"

  echo "Running 'make tools' within the Terraform Provider codebase.."
  cd "${outputDirectory}"
  make tools

  echo "Running 'make fmt' on the generated code.."
  make fmt

  cd "${DIR}"
}

function prepareTerraformProvider {
  local workingDirectory=$1
  local providerRepo=$2

  echo "Removing any existing working directory.."
  cd "${DIR}"
  rm -rf "$workingDirectory"

  echo "Cloning Terraform Provider $providerRepo into $workingDirectory.."
  git clone "$providerRepo" "$workingDirectory"

  echo "Preparing the repository for generation"
  cd "${DIR}"
  cd "${workingDirectory}"
  make prepare

  cd "${DIR}"
}

function runFmtImportsAndGenerate {
  local workingDirectory=$1

  cd "${workingDirectory}"

  echo "Running 'go mod vendor'.."
  go mod vendor

  echo "Running 'make tools'.."
  make tools

  echo "Running 'make fmt'.."
  make fmt

  echo "Running 'make goimports'.."
  make goimports

  echo "Running 'make generate'.."
  make generate

  echo "Running 'make terrafmt'.."
  make terrafmt

  cd "${DIR}"
}

function conditionallyCommitAndPushTerraformProvider {
  local workingDirectory=$1
  local sha=$2
  local branch="auto-pandora-pr/$sha"

  cd "${DIR}"
  cd "$workingDirectory"
  if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
    echo "Committing and Pushing the changes"

    # commit the generated changes
    git checkout -b "$branch"
    git config user.name "hc-github-team-tf-azure"
    git config user.email "<>"
    git add --all
    git commit -m "Updating based on $sha"

    # then update the dependencies
    go mod tidy
    go mod vendor
    if [[ $(git status --porcelain | wc -l) -gt 0 ]]; then
      git add --all
      git commit -m "Updating dependencies based on $sha"
    fi

    # NOTE: we're intentionally force-pushing here in-case this PR is
    # open and other changes (e.g. to the generator) get included
    git push origin "$branch" -f
  else
    echo "No changes detected - skipping commit/push"
  fi
}

function getSwaggerSubmoduleSha {
  local submodulePath=$1

  cd "${DIR}"
  cd "$submodulePath"
  git rev-parse --short HEAD
}

function cleanup {
  local outputDirectory=$1

  cd "${DIR}"
  echo "Removing temporary working directory $outputDirectory.."
  rm -rf "$outputDirectory"
}

function main {
  local apiDefinitionsDirectory="./api-definitions"
  local swaggerSubmodule="./submodules/rest-api-specs"
  local outputDirectory="tmp/terraform-provider-azurerm"
  local providerRepo="git@github.com:hashicorp/terraform-provider-azurerm.git"
  local sha

  buildAndInstallDependencies
  sha=$(getSwaggerSubmoduleSha "$swaggerSubmodule")
  prepareTerraformProvider "$outputDirectory" "$providerRepo"
  runWrapper "$apiDefinitionsDirectory" "$outputDirectory"
  runFmtImportsAndGenerate "$outputDirectory"
  conditionallyCommitAndPushTerraformProvider "$outputDirectory" "$sha"
  cleanup "$outputDirectory"
}

main