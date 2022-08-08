using Xunit;

namespace DemoApp.Tests;

public class CellTest
{
    // [Fact]
    // public void HasIdProperty()
    // {
    //     // assign
    //     var cell = new CellState(1);
    //     
    //     // act
    //     var cellId = cell.Id;
    //
    //     
    //     // assert
    //     Assert.Equal(1, cellId);
    //     
    //
    // }
    //
    // [Fact]
    // public void HasMagicSquareInts()
    // {
    //     var cell = new CellState(1);
    //     var cellMagic = cell.MagicSquare3X3Ints;
    //     var cellMagicLength = cellMagic.Count();
    //     Assert.Equal(9, cellMagicLength);
    // }
    //
    // [Fact]
    // public void HasValueProperty()
    // {
    //     var cell = new CellState(1);
    //     var cellValue = cell.Value;
    //     Assert.Equal(6, cellValue);
    // }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void OutlineData(int input)
    {
        Console.WriteLine(input);
    }
}