using Xunit;

namespace MetodyNumeryczneLab3.TestyJednostkowe;

public class LabCalcsTests
{
    [Fact]
    public void PrawidloweDane_ObliczMetodaSiecznych_Zwraca_PrawidloweWyniki()
    {
        const double x0 = -2;
        const double x1 = 2;
        const double tolerancja = 0.000001;
        const ushort maxLiczbaIteracji = 7;
        const double oczekiwanePrzyblizenieMiejscaZerowego = 0.14635900; // dokładniej: 0.14635950569335995
        const double oczekiwanePrzyblizenieMiejscaZerowegoMax = 0.14636000;
        var labCalcs = new LabCalcs();
        
        var wyniki = labCalcs.ObliczMetodaSiecznych(x0, x1, tolerancja);
        
        Assert.NotNull(wyniki);
        Assert.True(wyniki.IloscIteracji == maxLiczbaIteracji);
        Assert.True(wyniki.MiejsceZerowe is > oczekiwanePrzyblizenieMiejscaZerowego and < oczekiwanePrzyblizenieMiejscaZerowegoMax);
    }
    [Fact]
    public void PrawidloweDane_ObliczMetodaBisekcji_Zwraca_PrawidloweWyniki()
    {
        const double x0 = -2;
        const double x1 = 2;
        const double tolerancja = 0.000001;
        const ushort maxLiczbaIteracji = 22;
        const double oczekiwanePrzyblizenieMiejscaZerowego = -0.043736457; // dokładniej: -0.04373645782470703
        const double oczekiwanePrzyblizenieMiejscaZerowegoMax = -0.043737411; // wynik z iteracji nr 21
        var labCalcs = new LabCalcs();
        
        var wyniki = labCalcs.ObliczMetodaBisekcji(x0, x1, tolerancja);
        Assert.NotNull(wyniki);
        Assert.True(wyniki.IloscIteracji == maxLiczbaIteracji);
        Assert.True(wyniki.MiejsceZerowe is < oczekiwanePrzyblizenieMiejscaZerowego and > oczekiwanePrzyblizenieMiejscaZerowegoMax);
    }
}