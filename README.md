# Metadata Service

A simple service to showcase some C# ASP.NET Core concepts.

  ### Installation

```sh
$ cd MetadataService/
$ dotnet ef database update
$ dotnet run
```

Some useful commands (requires curl & jq) :
```sh
$  curl --cookie "session-id=ffc12caf-0d3d-42aa-b7c9-991e21020c9e" http://localhost:5000/api/Metadata/ | jq
$  curl --cookie "session-id=ffc12caf-0d3d-42aa-b7c9-991e21020c9e" http://localhost:5000/api/Metadata/206211246 | jq
```

