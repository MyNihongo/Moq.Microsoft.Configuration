[![Version](https://img.shields.io/nuget/v/MoqMicrosoftConfiguration?style=plastic)](https://www.nuget.org/packages/MoqMicrosoftConfiguration/)
Moq for Microsoft.Extensions.Configuration
***
In samples a NuGet package [Microsoft.Extensions.Configuration.Binder](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Binder/) is used.
Setup primitive values like `int`, `string`, `decimal`, etc.
```cs
[Fact]
public void SetupValues()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupValue<int>("my_key")
        .Returns(123);

    var result = mockConfiguration.Object
        .Get<int>("my_key");
}
```
Setup an enumerable of primitive values. Later the values can be retrieved as `IEnumerable<T>`, `T[]`, `List<T>`, etc.
```cs
[Fact]
public void SetupEnumerable()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupEnumerable<int>("my_key")
        .Returns(new [] { 1, 2, 3, 4 });

    var result = mockConfiguration.Object
        .Get<int[]>("my_key");
}
```