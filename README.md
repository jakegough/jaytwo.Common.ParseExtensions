# jaytwo.Common.ParseExtensions

A library with some extension methods to help working with parsing strings into basic types.


## Usage

`Parse` and `Parse_OrNull` extension methods for common primitives: `bool`, `short`, `int`, `long`, `float`, `double`, `ushort`, `uint`, `ulong`, `DateTime`, `decimal`, `Guid`, `Uri`.  

```cs
using jaytwo.Common.ParseExtensions
...
// parse string to int, throws exception on failure
int intValue = stringValue.ParseInt();

// parse string to int, swallow exception on failure and returns null
int? intValue = stringValue.ParseIntOrNull();

// parse string to int, swallow exception on failure, use -1 as default value
int intValue = stringValue.ParseIntOrNull() ?? -1;

// parses true/false
bool boolValue = stringValue.ParseBool();

// parses Yes/No (case insensetive)
bool boolValue = stringValue.ParseBool(BoolStyles.YesNo);
```

## Build

### Makefile
That's right, this is a .NET Core project written in C#... with a `Makefile`.  `Makefile`s have been used by developers to define
builds for generations.  I'm a proponent of _documentation as code_, so instead of populating the readme describing the steps
necessary to build the project, I'd rather just have the `Makefile` contain the very steps used to build.

#### Installing `make`
If you're on windows, just install it with [Chocolatey](https://chocolatey.org/).

```bash
choco install make
```

#### Running `make`
If you're working on this project in windows, life will be better if you forget you're on windows.  When you need to interact with the commandline, open a _Git Bash_ window instead of a _Command Prompt_ or _Powershell_ window.  Then, just navigate to the project directory containing the `Makefile` and type `make`.  If you have docker installed, you can build with `make docker-build`.

#### Other `make` Targets

* `make clean` - Purge past build artifacts in the `obj`, `bin`,  `publish`, `out`, and `testResults` directories.
* `make test` - Runs unit tests.
* `make pack` - Creates the nuget package, with the version defined in the `.csproj` file.
* `make pack-beta` - Creates the nuget package, suffixed with a datestamp as a beta version.
* `make docker-test`, `make docker-pack`, etc - Runs the build target inside the docker environment, just like it will on the CI host.
* ... and many more!

### Dockerfile
You may be asking yourself, "This isn't even an app, why is there a `Dockerfile`?'"  Well, it's because Docker is awesome and CI before Docker was a nightmare.  Thanks to containers, I don't have to worry about obscure dependencies or conflicts on the build host.  The `Dockerfile` contains a complete definition for the build environment.
