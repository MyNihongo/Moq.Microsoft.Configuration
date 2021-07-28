[![Version](https://img.shields.io/nuget/v/MoqMicrosoftConfiguration?style=plastic)](https://www.nuget.org/packages/MoqMicrosoftConfiguration/)
[![Nuget downloads](https://img.shields.io/nuget/dt/MoqMicrosoftConfiguration?label=nuget%20downloads&logo=nuget&style=plastic)](https://www.nuget.org/packages/MoqMicrosoftConfiguration/)   
Moq for Microsoft.Extensions.Configuration
***
Access values by specifying a path to the value in `[]` and with `:`.
```cs
[Fact]
public void SetupConfiguration()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupConfiguration()
        .Returns(new
        {
            String = "string",
            ObjectArray = new []
            {
                new { Float = 1.23f, String = "string1" },
                new { Float = 4.56f, String = "string2" }
            },
            Object = new
            {
                Bool = true,
                IntArray = new [] { 1, 2 },
                NestedObject = new
                {
                    Ulong = 1UL,
                    DeepObject = new
                    {
                        Uint = 123u,
                        DoubleArray = new [] { 12.3d, 45.6d }
                    }
                }
            }
        });

    // First level
    var @string = mockConfiguration.Object["String"]; // "string"
    var objectFloat1 = mockConfiguration.Object.GetValue<float>("ObjectArray:0:Float"); // 1.23
    var objectString1 = mockConfiguration.Object.GetValue<string>("ObjectArray:0:String"); // "string1"
    var objectFloat2 = mockConfiguration.Object.GetValue<float>("ObjectArray:1:Float"); // 4.56
    var objectString2 = mockConfiguration.Object.GetValue<string>("ObjectArray:1:String"); // "string2"

    // Second level
    var @bool = mockConfiguration.Object.GetValue<bool>("Object:Bool"); // true
    var intArray = mockConfiguration.Object.GetSection("Object:IntArray").Get<int[]>(); // [1, 2]
    var intItem1 = mockConfiguration.Object.GetValue<int>("Object:IntArray:0"); // 1
    var intItem2 = mockConfiguration.Object.GetValue<int>("Object:IntArray:1"); // 2

    // Third level
    var @ulong = mockConfiguration.Object.GetValue<ulong>("Object:NestedObject:Ulong"); // 1

    // Fourth level
    var @uint = mockConfiguration.Object.GetValue<ulong>("Object:NestedObject:DeepObject:Uint"); // 123
    var doubleArray = mockConfiguration.Object.GetSection("Object:NestedObject:DeepObject:DoubleArray").Get<double[]>(); // [12.3, 45.6]
    var doubleItem1 = mockConfiguration.Object.GetValue<double>("Object:NestedObject:DeepObject:DoubleArray:0"); // 12.3
    var doubleItem2 = mockConfiguration.Object.GetValue<double>("Object:NestedObject:DeepObject:DoubleArray:1"); // 45.6
}
```
Values can also be accessed from the section by calling `GetSection()`.
```cs
[Fact]
public void SetupSection()
{
    var mockConfiguration = new Mock<IConfiguration>();

    mockConfiguration
        .SetupConfiguration()
        .Returns(new
        {
            String = "string",
            ObjectArray = new []
            {
                new { Int = 1, String = "string1" },
                new { Int = 2, String = "string2" }
            },
            Object = new
            {
                Bool = true,
                IntArray = new [] { 1, 2 },
                NestedObject = new
                {
                    Ulong = 1UL,
                    DeepObject = new
                    {
                        Uint = 123u,
                        DoubleArray = new [] { 12.3d, 45.6d }
                    }
                }
            }
        });

    // First level
    var @string = mockConfiguration.Object.GetValue<string>("String"); // "string"
    var objectSection = mockConfiguration.Object.GetSection("ObjectArray");
    var objectFloat1 = objectSection.GetValue<float>("0:Float"); // 1.23
    var objectString1 = objectSection.GetValue<string>("0:String"); // "string1"
    var objectFloat2 = objectSection.GetValue<float>("1:Float"); // 4.56
    var objectString2 = objectSection.GetValue<string>("1:String"); // "string2"

    // Second level
    var secondSection = mockConfiguration.Object.GetSection("Object");

    var @bool = secondSection.GetValue<bool>("Bool"); // true
    var intSection = secondSection.GetSection("IntArray");
    var intItem1 = intSection.GetValue<int>("0"); // 1
    var intItem2 = intSection.GetValue<int>("1"); // 2

    // Third level
    // or mockConfiguration.Object.GetSection("Object:NestedObject");
    var thirdSection = secondSection.GetSection("NestedObject");

    var @ulong = thirdSection.GetValue<ulong>("Ulong"); // 1

    // Fourth level
    // or mockConfiguration.Object.GetSection("Object:NestedObject:DeepObject");
    // or secondSection.GetSection("NestedObject:DeepObject");
    var fourthSection = thirdSection.GetSection("DeepObject");

    var @uint = fourthSection.GetValue<ulong>("Uint"); // 123
    var doubleSection = fourthSection.GetSection("DoubleArray"); // [12.3, 45.6]
    var doubleItem1 = doubleSection.GetValue<double>("0"); // 12.3
    var doubleItem2 = doubleSection.GetValue<double>("1"); // 45.6
}
```