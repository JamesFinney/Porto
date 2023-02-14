# Porto

The Porto library is a collection of utility, extension, attribute, and miscellaneous classes to assist your development. I've been copying these classes between projects for far too long so it was about time to put them into a library and pull them down from Nuget. The library includes:

- EnvironmentVariableAttribute and parser for setting object properties from the environment.
- General utilities: certificate loading, IP address and DNS extraction;
- Wrappers with interfaces to common .NET classes to improve unit testing, e.g. File, Directory...

## Installation

Porto can be installed via Nuget using the Visual Studio package manager (search for 'Porto') or by running the command below:

```bash
dotnet add package Porto
```

## Usage

### Environment Variable Attribute

Add the attribute to any properties that you'd like to set using Environment Variables. Then call the EnvironmentVariableParser.Parse<T>() method to load the properties from the Environment into a new instance (or an existing instance if you provide it as an argument).

The environment variable parser currently supports the following data types:
- `bool`
- `byte`
- `sbyte`
- `char`
- `decimal`
- `double`
- `float`
- `int`
- `uint`
- `long`
- `ulong`
- `short`
- `string`
- `List<string>`
- `string[]`

Support for lists/arrays of any core .NET data type will be added in the near future, e.g. `List<int>`, `double[]`

An example of how to use the EnvironmentVariableAttribute is shown below


```csharp
using Porto.Attributes;

public class MySettings
{
    // When no Presence is specified as the second argument then it defaults to Mandatory.
    [EnvironmentVariable("CONNECTION_STRING")]
    public string ConnectionString { get; set; }

    // An optional variable will not throw an exception if it's not set in the environment.
    [EnvironmentVariable("SOME_PASSWORD", Presence.Optional)]
    public string Password { get; set; }
}

// Creates a new instance of MySettings, processing any EnvironmentVariable attributes along the way.
var settings = EnvironmentVariableParser.Parse<MySettings>();

// Loads enivronment variables in to an existing instance
var settings = new MySettings();
_ = EnvironmentVariableParser.Parse<MySettings>(settings);

```

### Wrappers

If you've created a class that accesses the disk (for example), the only way to unit test is to interface this disk access. Porto wraps these classes with an interface so that DI can be used and unit tests can be written. Current wrapper interfaces include:

- IPFile = wraps Microsoft's System.IO.File static class
- IPDirectory = wraps Microsoft's System.IO.Directory static class
- IPZipFile = wraps Microsoft's System.IO.Compression.ZipFile static class

These interfaces cover all methods in Microsoft's .NET 6 implementation.

A noddy unit test example is shown below.

```csharp
using Porto.System.IO;

// This is the class we want to test
public class TestSubject
{
    private readonly IPFile _fileAccess;

    public TestSubject(IPFile fileAccess)
    {
        _fileAccess = filesAccess
    }

    public void TestMethod(string path)
    {
        if (!_fileAccess.Exists(path))
            throw new Exception();

        // do something useful
    }
}

// ... and this is the NUnit test class
[TestFixture]
public class TestClass
{
    [Test]
    public void Test()
    {
        // Arrange
        var mockFile = new Mock<IPFile>();
        mockFile.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

        var testSubject = new TestSubject(mockFile.Object);

        // Act / Assert
        Assert.Throws<Exception>(() => testSubject.TestMethod("what?"));
    }
}

```

### Utilities

Porto currently contains two utility classes:
- INetworkUtility = methods for retrieving the host's IP address/addresses
- ICertificatesUtility = methods for loading X509 Certificates from the LocalMachine and file

### Extensions

Porto currently contains one extension class:
- HttpContextExtensions = methods for retrieving the DNS name or IP address of the client; a method for validating the client certificate against a list of allowed certificates.

## License

The Porto library is distributed under the MIT license, the details of which can be found here: [MIT](https://choosealicense.com/licenses/mit/)
