using MetodyNumeryczneLab3;


const double x0 = -2;
const double x1 = 2;
const double tolerancja = 0.000001;

var labCalcs = new LabCalcs();
var wynikiMetodaSiecznych = labCalcs.ObliczMetodaSiecznych(x0, x1, tolerancja);

Console.WriteLine("==================== [Metoda siecznych] ====================\n" +
                  $"Miejsce zerowe: {wynikiMetodaSiecznych.MiejsceZerowe}," +
                  $" ilość iteracji {wynikiMetodaSiecznych.IloscIteracji}");


var wynikiMetodaBisekcji = labCalcs.ObliczMetodaBisekcji(x0, x1, tolerancja);

Console.WriteLine("==================== [Metoda bisekcji] ====================\n" +
                  $"Miejsce zerowe: {wynikiMetodaBisekcji.MiejsceZerowe}," +
                  $" ilość iteracji {wynikiMetodaBisekcji.IloscIteracji}");
