namespace CalculadoraTests;

using Calculadora;

public class CalculadoraTests
{
    private Calculadora _calc;

    public CalculadoraTests()
    {
        _calc = new Calculadora(DateTime.Now.ToShortDateString());
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(3, 4, 7)]
    [InlineData(5, 6, 11)]
    public void Somar(int value1, int value2, int expected)
    {
        int result = _calc.Somar(value1, value2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(20, 19, 1)]
    [InlineData(40, 33, 7)]
    [InlineData(60, 55, 5)]
    public void Subtrair(int value1, int value2, int expected)
    {
        int result = _calc.Subtrair(value1, value2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 7, 14)]
    [InlineData(3, 4, 12)]
    [InlineData(5, 6, 30)]
    public void Multiplicar(int value1, int value2, int expected)
    {
        int result = _calc.Multiplicar(value1, value2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(8, 2, 4)]
    [InlineData(9, 3, 3)]
    [InlineData(2, 2, 1)]
    public void Dividir(int value1, int value2, int expected)
    {
        int result = _calc.Dividir(value1, value2);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void DividirPorZero()
    {
        Assert.Throws<DivideByZeroException>(
            () => _calc.Dividir(1, 0)
        );
    }


    [Fact]
    public void Historico()
    {
        _calc.Somar(2, 3);
        _calc.Somar(4, 5);
        _calc.Somar(6, 7);
        _calc.Somar(8, 9);

        var historico = _calc.Historico();

        Assert.NotEmpty(historico);
        Assert.Equal(3, historico.Count);
    }
}