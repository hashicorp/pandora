#!/bin/bash

set -e

DIR="$(cd "$(dirname "$0")" && pwd)/.."

function buildAndInstallDependencies {
  cd "${DIR}"

  echo "Building and Installing the Data API onto the GOPATH"
  cd ./tools/data-api
  go install
  cd "${DIR}"

  echo "Building and Installing the Data API Differ onto the GOPATH"
  cd ./tools/data-api-differ
  go install
  cd "${DIR}"
}

function checkoutAPIDefinitionsFromMainInto {
  local workingDirectory="$1"
  local existingPandoraDirectory="${DIR}"

  cd "${DIR}"

  echo "Removing any existing directory at ${workingDirectory}.."
  rm -rf "$workingDirectory"

  echo "Checking out a secondary copy of hashicorp/pandora from this repository.."
  git clone --depth 1 --branch main "file://$existingPandoraDirectory" "$workingDirectory"
  cd "$workingDirectory"

  echo "Resetting the secondary working directory"
  git reset --hard
  git clean -xdf

  echo "Checking out the 'main' branch in the copy"
  git checkout main

  echo "Returning to the original working directory.."
  cd "${DIR}"
}

function ensureDirectoryExists {
  local directory="$1"

  echo "Removing any existing directory at ${directory}.."
  rm -rf "$directory"

  echo "Recreating the directory ${directory}"
  mkdir -p "${directory}"
}

function runBreakingChangeDetector {
  local initialApiDefinitionsDirectory="$1"
  local updatedApiDefinitionsDirectory="$2"
  local outputFilePath="$3"

  echo "Detecting Breaking Changes between ${initialApiDefinitionsDirectory} and ${updatedApiDefinitionsDirectory}.."
  data-api-differ detect-breaking-changes --initial-path="${initialApiDefinitionsDirectory}" --updated-path="${updatedApiDefinitionsDirectory}" --output-file-path="${outputFilePath}"
}

function runChangeDetector {
  local initialApiDefinitionsDirectory="$1"
  local updatedApiDefinitionsDirectory="$2"
  local outputFilePath="$3"

  echo "Detecting Changes between ${initialApiDefinitionsDirectory} and ${updatedApiDefinitionsDirectory}.."
  data-api-differ detect-changes --initial-path="${initialApiDefinitionsDirectory}" --updated-path="${updatedApiDefinitionsDirectory}" --output-file-path="${outputFilePath}"
}

function runStaticIdentifierDetector {
  local initialApiDefinitionsDirectory="$1"
  local updatedApiDefinitionsDirectory="$2"
  local outputFilePath="$3"

  echo "Detecting any new Static Identifiers between ${initialApiDefinitionsDirectory} and ${updatedApiDefinitionsDirectory}.."
  data-api-differ output-resource-id-segments --initial-path="${initialApiDefinitionsDirectory}" --updated-path="${updatedApiDefinitionsDirectory}" --output-file-path="${outputFilePath}"
}

function main {
  local tempDirectory="./pandora-from-main"
  local initialApiDefinitionsDirectory="${DIR}/api-definitions"
  local updatedApiDefinitionsDirectory="${tempDirectory}/api-definitions"
  local outputDirectory="$1"

  buildAndInstallDependencies
  checkoutAPIDefinitionsFromMainInto "$tempDirectory"
  ensureDirectoryExists "$outputDirectory"

  runBreakingChangeDetector "$initialApiDefinitionsDirectory" "$updatedApiDefinitionsDirectory" "${outputDirectory}/breaking-changes.md"
  runChangeDetector "$initialApiDefinitionsDirectory" "$updatedApiDefinitionsDirectory" "${outputDirectory}/changes.md"
  runStaticIdentifierDetector "$initialApiDefinitionsDirectory" "$updatedApiDefinitionsDirectory" "${outputDirectory}/static-identifiers.md"
}

main "$1"