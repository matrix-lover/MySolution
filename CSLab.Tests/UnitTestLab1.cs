using Xunit;

namespace CSLab.Tests;

public class RectangleTests
{
    [Theory]
    [InlineData(2.5, 4.0, 10.0)]
    [InlineData(1.0, 1.0, 1.0)]
    public void CalculateArea_WithValidSides_ReturnsCorrectArea(double sideA, double sideB, double expectedArea)
    {

        var rectangle = new Rectangle(sideA, sideB);

        var result = rectangle.Area;

        Assert.Equal(expectedArea, result);
    }

    [Theory]
    [InlineData(5.0, 10.0, 30.0)]
    public void CalculatePerimeter_WithValidSides_ReturnsCorrectPerimeter(double sideA, double sideB, double expectedPerimeter)
    {
        var rectangle = new Rectangle(sideA, sideB);

        var result = rectangle.Perimeter;

        Assert.Equal(expectedPerimeter, result);
    }

    [Theory]
    [InlineData(0.0, 5.0)]
    [InlineData(5.0, 0.0)]
    [InlineData(0.0, 0.0)]
    public void Constructor_WithZeroSide_ThrowsArgumentException(double sideA, double sideB)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(sideA, sideB));
    }

    [Theory]
    [InlineData(-5.0, 10.0)]
    [InlineData(5.0, -10.0)]
    [InlineData(-5.0, -10.0)]
    public void Constructor_WithNegativeSide_ThrowsArgumentOutOfRangeException(double sideA, double sideB)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(sideA, sideB));
    }
}

public class PointTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(5, 10)]
    [InlineData(-3, 7)]
    [InlineData(int.MaxValue, int.MinValue)]
    public void Constructor_WithValidCoordinates_SetsProperties(int x, int y)
    {
        var point = new Point(x, y);

        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Theory]
    [InlineData(0, 0, 3, 4, 5.0)]
    [InlineData(1, 2, 4, 6, 5.0)]
    [InlineData(-1, -1, 2, 3, 5.0)]
    public void LengthSide_WithDifferentPoints_ReturnsCorrectDistance(int x1, int y1, int x2, int y2, double expectedDistance)
    {
        var point1 = new Point(x1, y1);
        var point2 = new Point(x2, y2);

        var result = Point.LengthSide(point1, point2);

        Assert.Equal(expectedDistance, result);
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        var point = new Point(5, 10);

        var result = point.ToString();

        Assert.Equal("(5, 10)", result);
    }
}

public class FigureTests
{
    [Fact]
    public void Constructor_WithThreePoints_SetsPropertiesCorrectly()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 0);
        var p3 = new Point(0, 4);
        
        var figure = new Figure(p1, p2, p3);
        
        Assert.Equal(p1, figure.P1);
        Assert.Equal(p2, figure.P2);
        Assert.Equal(p3, figure.P3);
        Assert.Null(figure.P4);
        Assert.Null(figure.P5);
    }

    [Fact]
    public void Constructor_WithFourPoints_SetsPropertiesCorrectly()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 0);
        var p3 = new Point(3, 4);
        var p4 = new Point(0, 4);
        
        var figure = new Figure(p1, p2, p3, p4);
        
        Assert.Equal(p1, figure.P1);
        Assert.Equal(p2, figure.P2);
        Assert.Equal(p3, figure.P3);
        Assert.Equal(p4, figure.P4);
        Assert.Null(figure.P5);
    }

    [Fact]
    public void Constructor_WithFivePoints_SetsPropertiesCorrectly()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 0);
        var p3 = new Point(3, 4);
        var p4 = new Point(0, 4);
        var p5 = new Point(1, 1);
        
        var figure = new Figure(p1, p2, p3, p4, p5);
        
        Assert.Equal(p1, figure.P1);
        Assert.Equal(p2, figure.P2);
        Assert.Equal(p3, figure.P3);
        Assert.Equal(p4, figure.P4);
        Assert.Equal(p5, figure.P5);
    }

    [Fact]
    public void PerimeterCalculator_WithTriangle_ReturnsCorrectPerimeter()
    {
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 0);
        var p3 = new Point(0, 4);
        var figure = new Figure(p1, p2, p3);
        
        var result = figure.PerimeterCalculator();
        
        Assert.Equal(12.0, result, 5);
    }
}