# Porto

The Porto library is a collection of utility, extension, attribute, and miscellaneous classes to assist your development. For too long I've been copying these classes between projects, so it was about time to put them in a single library that could be pulled down from Nuget. The library includes:

- General utilities: certificate loading, IP address and DNS extraction;
- Wrappers with interfaces to common .NET classes to improve unit testing, e.g. File, Directory...
- EnvironmentVariableAttribute and parser for setting object properties from the environment.


## Installation

Porto can be installed via Nuget using the Visual Studio package manager (search for 'Porto') or by running the command below:

```bash
dotnet add package Porto
```

## Usage

### Environment Variable Attribute

Add the attribute to any properties that you'd like to set using Environment Variables. Then call the EnvironmentVariableParser.Parse<T>() method to the properties from the Environment.

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

```

### Wrappers

If you've created a class that accesses the disk (for example), the only way to unit test is to interface this disk access. Porto wraps these classes with an interface so that DI can be used and unit tests can be written. A noddy example is shown below.

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
        mockFile.Setuo(x => x.Exists(It.IsAny<string>())).Throws<Exception>();

        var testSubject = new TestSubject(mockFile.Object);

        // Act / Assert
        Assert.Throws<Exception>(() => testSubject.TestMethod("what?"));
    }
}

```

## License

The Porto library is distributed under the MIT license, the details of which can be found here: [MIT](https://choosealicense.com/licenses/mit/)