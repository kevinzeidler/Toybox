using Xunit;

namespace DemoApp.Tests;

public class HelloBuilderTest
{
    [Fact]
    public void ReturnsHelloSuccessfully()
    {
        // assign
        var helloBuilder = new HelloBuilder();
        var expectedResult = "Hello, Builder";

        // act
        var actualResult = helloBuilder.GetHello();

        // assert
        Assert.Equal(expectedResult, actualResult);
    }
}