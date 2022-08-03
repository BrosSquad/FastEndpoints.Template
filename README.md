<h1 align="center">
   <img alt="cgapp logo" src="https://github.com/BrosSquad/FastEndpoints.Template/blob/main/.template.config/logo.png" width="224px"/><br/>
</h1>
<p align="center">Minimal Fast Endpoints template with Integration Testing</p>

<p align="center">
  <a href="https://pkg.go.dev/github.com/create-go-app/cli/v3?tab=doc" target="_blank"><img src="https://img.shields.io/nuget/dt/FastEndpoints.Template?style=for-the-badge" alt="Nuget downloads" /></a>&nbsp;<img src="https://img.shields.io/badge/license-apache_2.0-red?style=for-the-badge&logo=none" alt="license" /></p>

## Installation

Install .NET template

```bash
  dotnet new --install FastEndpoints.Template
```
    
## Usage/Examples

```bash
  dotnet new fastendpoints --name Example
```

- More options coming soon


## Folder structure

```sh
  src/
  ├─ API/
  tests/
  ├─ API.Integration.Tests/
```

## Packages 

### API project consists of these packages:
- FastEndpoints
- FastEndpoints.Generator (Source generation)
- FastEndpoints.Swagger

### API.Integration.Tests project consists of these packages:
- xUnit
- FluentAssertions
- Microsoft.AspNetCore.Mvc.Testing

## Support

If you are having problems, please let us know by [raising a new issue](https://github.com/BrosSquad/FastEndpoints.Template/issues/new).

## License

This project is licensed with the [Apache License 2.0](LICENSE).
