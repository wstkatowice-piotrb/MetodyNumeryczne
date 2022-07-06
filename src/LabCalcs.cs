using MetodyNumeryczneLab3.Responses;

namespace MetodyNumeryczneLab3;

public class LabCalcs
{
    // Wyrażenie funkcji x^3−0.165*x^2+0.0003993
    private static double Func(double x) 
        => Math.Pow(x, 3) - 0.165 * Math.Pow(x, 2) + 0.0003993;

    public WynikiObliczen ObliczMetodaSiecznych(double x0, double x1, double tolerancja, ushort maxLiczbaIteracji = 20)
    {
        ushort iterations = 0;
        double pierwiastekRownania = 0,
                xm = 0;
        do
        {

            var wartoscBezwzgledna = UzyskajWartoscBezwzgledna(x0, x1);

            // obliczenie pierwiastka równania
            pierwiastekRownania = Func(wartoscBezwzgledna) * Func(x0);

            x0 = x1;
            x1 = wartoscBezwzgledna;
            // aktualizacja liczby iteracji
            iterations++;

            // przerwanie pętli, jeżeli pierwiastek równania wynosi 0
            if (pierwiastekRownania == 0.0)
                break;
            
            xm = UzyskajWartoscBezwzgledna(x0, x1);
        } while ( Math.Abs(xm - x0) >= tolerancja || iterations >= maxLiczbaIteracji);

        return new WynikiObliczen
        {
            IloscIteracji = iterations,
            MiejsceZerowe = xm
        };
    }

    public WynikiObliczen ObliczMetodaBisekcji(double x0, double x1, double tolerancja)
    {
        ushort iteracje = 0;
        if (Func(x0) * Func(x1) >= 0)
        {
            throw new InvalidOperationException("Złe dane wejściowe x1, x2");
        }
 
        var c = x0;
        while ((x1 - x0) >= tolerancja)
        {
            // wyznaczenie punktu pomiędzy dwoma punktami
            c = (x0 + x1) / 2;
 
            // przerwanie pętli, jeżeli pierwiastek równania wynosi 0
            if (Func(c) == 0.0)
                break;
 
            // określenie strony
            if (Func(c) * Func(x0) < 0)
                x1 = c;
            else
                x0 = c;

            iteracje++;
        }
        
        return new WynikiObliczen
        {
            IloscIteracji = iteracje,
            MiejsceZerowe = c
        };
    }
    
    public double UzyskajWartoscBezwzgledna(double x1, double x2)
        => (x1 * Func(x2) - x2 * Func(x1)) / (Func(x2) - Func(x1));
}