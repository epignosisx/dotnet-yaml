# dotnet-yaml
.NET Global Tool to validate yaml files

## Installation
```
dotnet tool install --global dotnet-yaml --version 1.0.0
```

### Usage

```
yaml --input <file or dir to process> --filter <glob to filter dir input>
```

Example:

Process current directory for `.yml` files
```
$ yaml --input . --filter *.yml
```

Process directory `/foo/bar` for `.yml` or `.yaml` files
```
$ yaml --input /foo/bar --filter *.yml --filter *.yaml
```

**Output**: Writes to standard error invalid files:
```
test-bad.yaml invalid: Lin: 1, Col: 4, Chr: 15
```

For verbose output pass flag `--verbose`:
```
$ yaml --filter *.yml --filter *.yaml --verbose
test-good.yml: valid
test-bad.yaml invalid: Lin: 1, Col: 4, Chr: 15
```
