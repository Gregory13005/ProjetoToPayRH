using System;

public class Decimo
{
    public double CalcularDecimoTerceiro(double salarioMensal, int mesesTrabalhados)
    {
        double valorDecimoTerceiro = CalcularTerceiro(salarioMensal, mesesTrabalhados);
        return valorDecimoTerceiro;
    }

    private double CalcularTerceiro(double salarioMensal, int mesesTrabalhados)
    {
        double salarioAnual = salarioMensal * 12;
        double valorDecimoTerceiro = (salarioAnual / 12) * mesesTrabalhados;
        return valorDecimoTerceiro;
    }

    public void ExecutarCalculoDecimoTerceiro(ref double valorDecimoTerceiro)
    {
        Console.Clear();
        Console.WriteLine("Você selecionou Cálculo de Décimo Terceiro...\n");

        Console.Write("Digite o número de meses trabalhados: ");
        int mesesTrabalhados = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o salário mensal: ");
        double salarioMensal = Convert.ToDouble(Console.ReadLine());

        valorDecimoTerceiro = CalcularDecimoTerceiro(salarioMensal, mesesTrabalhados);
    }
}
