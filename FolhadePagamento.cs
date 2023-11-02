using System;

namespace ProjetoTopayRH
{
    class FolhadePagamento
    {
        public double SalarioMinimo { get; set; }
        public double TetoINSS { get; set; }
        public double DescontoTransporte { get; set; }
        public double DescontoValeRefeicao { get; set; }
        public double DescontoConvenioMedico { get; set; }
        public double DescontoConvenioOdontologico { get; set; }

        public double CalcularHolerite(Funcionario funcionario, double horasExtras)
        {
            double salarioLiquido = funcionario.Salario;

            // Cálculo do desconto do INSS
            if (funcionario.Salario <= SalarioMinimo)
            {
                funcionario.DescontoINSS = funcionario.Salario * 0.05;
            }
            else if (funcionario.Salario <= TetoINSS)
            {
                funcionario.DescontoINSS = funcionario.Salario * 0.11;
            }
            else
            {
                double valorExcedente = funcionario.Salario - TetoINSS;
                funcionario.DescontoINSS = TetoINSS * 0.11 + valorExcedente * 0.20;
            }

            salarioLiquido -= funcionario.DescontoINSS;
            salarioLiquido -= DescontoTransporte;
            salarioLiquido -= DescontoValeRefeicao;
            salarioLiquido -= DescontoConvenioMedico;
            salarioLiquido -= DescontoConvenioOdontologico;

          

            return salarioLiquido;
        }

    }
}
