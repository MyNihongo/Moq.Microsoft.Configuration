[![Version](https://img.shields.io/nuget/v/MoqMicrosoftConfiguration?style=plastic)](https://www.nuget.org/packages/MoqMicrosoftConfiguration/)  
Moq for Microsoft.Extensions.Configuration
***
## Setup the root section
Only class types or structs (e.g. instances which have properties) can be used to setup the root section.
```cs
[Fact]
public void SetupRoot()
{
    var mockConfiguration = new Mock<IConfiguration>();

     mockConfiguration
        .SetupRoot()
        .Returns(new
        {
            Int = 123,
            Bool = true,
            StringArray = new[] { "value1", "value2" }
        });

    var intResult = mockConfiguration.Object.GetValue<int>("Int"); // 123
    var boolResult = mockConfiguration.Object.GetValue<bool>("Bool"); // true
    var stringArrayResult = mockConfiguration.Object.GetSection("StringArray").Get<string[]>(); // ["value1","value2"]

    var stringItem1 = mockConfiguration.Object["StringArray:0"]; // "value1"
    var stringItem2 = mockConfiguration.Object["StringArray:1"]; // "value2"
}
```
## Setup a section
Primitive types and classes can be used to setup a section.
#### Primitive types
```cs
[Fact]
public void SetupSection()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupSection("my_key")
        .Returns(123.456m);

    var result = mockConfiguration.Object.GetValue<decimal>("my_key"); // 123.456
}
```
#### Classes
Access values by specifying a path to the value in `[]`.
```cs
[Fact]
public void SetupSection()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupSection("my_key")
        .Returns(new
        {
            String = "string",
            Int = 123,
            Decimal = 123.456m,
            StringArray = new [] { "value1", "value2", "value3" }
        });

    var stringResult = mockConfiguration.Object["my_key:String"]; // "string"
    var intResult = mockConfiguration.Object.GetValue<int>("my_key:Int"); // 123
    var decimalResult = mockConfiguration.Object.GetValue<decimal>("my_key:Decimal"); // 123.456
    var arrayResult = mockConfiguration.Object.GetSection("my_key:StringArray").Get<string[]>(); // ["value1","value2","value3"]

    var stringItem1 = mockConfiguration.Object["my_key:StringArray:0"]; // "value1"
    var stringItem2 = mockConfiguration.Object["my_key:StringArray:1"]; // "value2"
    var stringItem3 = mockConfiguration.Object["my_key:StringArray:2"]; // "value3"
}
```
Values can also be accessed from the section by calling `GetSection()`.
```cs
[Fact]
public void SetupSection()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupSection("my_key")
        .Returns(new
        {
            String = "string",
            Int = 123,
            Decimal = 123.456m,
            StringArray = new [] { "value1", "value2", "value3" }
        });

    var section = mockConfiguration.Object
        .GetSection("my_key");

    var stringResult = section.GetValue<string>("String"); // "string"
    var intResult = section.GetValue<int>("Int"); // 123
    var decimalResult = section.GetValue<decimal>("Decimal"); // 123.456
    var arrayResult = section.GetSection("StringArray").Get<string[]>(); // ["value1","value2","value3"]

    var stringItem1 = section["StringArray:0"]; // "value1"
    var stringItem2 = section["StringArray:1"]; // "value2"
    var stringItem3 = section["StringArray:2"]; // "value3"
}
```
## Setup a value
Setup primitive values like `int`, `string`, `decimal`, etc.
```cs
[Fact]
public void SetupValues()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupValue<int>("Int")
        .Returns(123);

    mockConfiguration
        .SetupValue<decimal>("Decimal")
        .Returns(123.456m);

    var intResult = mockConfiguration.Object.GetValue<int>("Int"); // 123
    var decimalResult = mockConfiguration.Object.GetValue<decimal>("Decimal"); // 123.456
}
```
## Setup lists
Setup an enumerable of primitive values. Later the values can be retrieved as `IEnumerable<T>`, `T[]`, `List<T>`, etc.
```cs
[Fact]
public void SetupEnumerable()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupChildren<int>("my_key")
        .Returns(new [] { 1, 2, 3, 4 });

    var result = mockConfiguration.Object.GetSection("my_key").Get<int[]>(); // [1,2,3,4]
}
```