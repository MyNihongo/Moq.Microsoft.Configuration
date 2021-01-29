[![Version](https://img.shields.io/nuget/v/MoqMicrosoftConfiguration?style=plastic)](https://www.nuget.org/packages/MoqMicrosoftConfiguration/)  
Moq for Microsoft.Extensions.Configuration
***
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
        .GetValue<int>("my_key");
}
```
Setup an enumerable of primitive values. Later the values can be retrieved as `IEnumerable<T>`, `T[]`, `List<T>`, etc.
```cs
[Fact]
public void SetupEnumerable()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupChildren<int>("my_key")
        .Returns(new [] { 1, 2, 3, 4 });

    var result = mockConfiguration.Object
        .GetValue<int[]>("my_key");
}
```
Setup a section with a class or a primitive value. Currently recursive section are **not supported**.
```cs
[Fact(DisplayName = "Setup with a primitive value")]
public void PrimitiveValue()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupSection<string>("my_key")
        .Returns("my_value");

     var result = mockConfiguration.Object
        .GetValue<string>("my_key");
}

[Fact(DisplayName = "Setup with a class")]
public void Class()
{
     var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupSection<dynamic>("my_key")
        .Returns(new
        {
            MyString = "string",
            MyInt = 123,
            MyDecimal = 123.456m,
            MyArray = new [] { "value1", "value2", "value3" }
        });

    var section = mockConfiguration.Object
        .GetSection("my_key");

    var stringResult = section.GetValue<string>("MyString");
    var intResult = section.GetValue<int>("MyInt");
    var decimalResult = section.GetValue<decimal>("MyDecimal");
    var arrayResult = section.GetSection("MyArray").Get<string[]>();
}
```