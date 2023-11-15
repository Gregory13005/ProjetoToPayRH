using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProjetoTopayRH
{
    public class Program
    {
        static Funcionarios funcionarios = new Funcionarios();
        static Decimo calcularDecimo = new Decimo();

        static void Main(string[] args)
        {
            while (true)
            {
                LogoTopayRH();
                Console.WriteLine("\n\nBem vindo a topayRh!\n\n");
                Thread.Sleep(1000);
                Console.WriteLine("Faça seu login!\n");
                Console.Write("Email de acesso: ");
                string emailDigitado = Console.ReadLine();

                Console.Write("Digite sua senha de acesso: ");
                string senhaDigitada = Console.ReadLine();

                bool loginSucesso = funcionarios.ValidarLogin(emailDigitado, senhaDigitada);

                if (loginSucesso)
                {
                    Console.WriteLine("\n\nBem vindo ao sistema!");
                    Thread.Sleep(1500);
                    MenuPrincipal();
                    break;
                }
                else
                {
                    Console.WriteLine("Email ou senha incorretos. Tente novamente.");
                    Thread.Sleep(2500);
                    Console.Clear();
                }
            }
        }

        static void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                LogoTopayRH();
                Console.WriteLine("\nBem-vindo ao menu principal.");
                Console.WriteLine("1. Cadastrar um novo colaborador");
                Console.WriteLine("2. Visualizar Colaboradores");
                Console.WriteLine("3. Calcular Décimo Terceiro");
                Console.WriteLine("4. Calcular Folha de Pagamento");
                Console.WriteLine("5. Sair");


                Console.Write("Escolha uma opção: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("Matrícula: ");
                        int matricula = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Idade: ");
                        int idade = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Salário: ");
                        double salario = double.Parse(Console.ReadLine());

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Cargo: ");
                        string cargo = Console.ReadLine();

                        Console.Write("Senha: ");
                        string senha = Console.ReadLine();

                        

                        funcionarios.CadastrarColaborador(nome, matricula, idade, salario, email, senha,cargo);

                        Console.WriteLine("Colaborador cadastrado com sucesso.");
                        Thread.Sleep(2000);
                        break;

                    case "2":
                        
                        
                        var colaboradores = funcionarios.ObterFuncionarios();

                        foreach (var colaborador in colaboradores)
                        {
                            Console.Clear(); // Limpar a tela
                            LogoTopayRH();
                            Console.WriteLine("Lista de Colaboradores: \n");
                            Console.WriteLine("Nome: " + colaborador.Nome);
                            Console.WriteLine("Matrícula: " + colaborador.Matricula);
                            Console.WriteLine("Email: " + colaborador.Email);
                            Console.WriteLine("Cargo: " + colaborador.Cargo);
                            Thread.Sleep(2000); // Pausa de 2 segundos
                            Console.WriteLine("Pressione algum botão para continuar:");
                            Console.ReadLine();

                        }
                        break;

                    case "3":
                        double valorDecimoTerceiro = 0;
                        calcularDecimo.ExecutarCalculoDecimoTerceiro(ref valorDecimoTerceiro);
                        Console.WriteLine("O valor do décimo terceiro é: " + valorDecimoTerceiro);
                        Thread.Sleep(2000);
                        break;

                    case "4":
                        Console.Write("Digite o nome do colaborador: ");
                        string nomeColaborador = Console.ReadLine();

                        Funcionario colaboradorSelecionado = funcionarios.ObterFuncionarioPorNome(nomeColaborador);

                        if (colaboradorSelecionado != null)
                        {
                            FolhadePagamento folhaDePagamento = new FolhadePagamento
                            {
                                SalarioMinimo = 1000.0,
                                TetoINSS = 5000.0,
                                DescontoTransporte = 200.0,
                                DescontoValeRefeicao = 100.0,
                                DescontoConvenioMedico = 150.0,
                                DescontoConvenioOdontologico = 50.0
                            };

                            double salarioLiquido = folhaDePagamento.CalcularHolerite(colaboradorSelecionado, 0); // 0 horas extras, você pode ajustar isso

                            // Exibir o nome do colaborador
                            Console.WriteLine("Colaborador: " + colaboradorSelecionado.Nome);
                            Console.WriteLine("Matricula: " + colaboradorSelecionado.Matricula);
                            Console.WriteLine("Cargo: " + colaboradorSelecionado.Cargo);
                            Console.WriteLine("\n");
                            // Usando StringBuilder para criar o layout da folha de pagamento
                            StringBuilder folhaPagamento = new StringBuilder();
                            folhaPagamento.AppendLine("=== Folha de Pagamento ===");
                            folhaPagamento.AppendLine($"Nome do Funcionário: {colaboradorSelecionado.Nome}");
                            folhaPagamento.AppendLine($"Salário Base: {colaboradorSelecionado.Salario:C}");
                            folhaPagamento.AppendLine($"Valor das Horas Extras: {0:C}");  // 0 horas extras, você pode ajustar isso
                            folhaPagamento.AppendLine($"Desconto INSS: {colaboradorSelecionado.DescontoINSS:C}");
                            folhaPagamento.AppendLine($"Desconto Transporte: {folhaDePagamento.DescontoTransporte:C}");
                            folhaPagamento.AppendLine($"Desconto Vale Refeição: {folhaDePagamento.DescontoValeRefeicao:C}");
                            folhaPagamento.AppendLine($"Desconto Convênio Médico: {folhaDePagamento.DescontoConvenioMedico:C}");
                            folhaPagamento.AppendLine($"Desconto Convênio Odontológico: {folhaDePagamento.DescontoConvenioOdontologico:C}");
                            folhaPagamento.AppendLine($"Salário Líquido: {salarioLiquido:C}");
                            folhaPagamento.AppendLine("===========================");

                            Console.WriteLine(folhaPagamento.ToString());
                            Thread.Sleep(6000);

                            Console.WriteLine("Pressione algum botão para continuar:");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Colaborador não encontrado.");
                            Thread.Sleep(5000);
                        }
                        break;

                    case "5":
                        Console.WriteLine("Saindo do sistema.");
                        Thread.Sleep(2000);
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }

        static void LogoTopayRH()
        {
            Console.WriteLine(@"
▀▀█▀▀ █▀▀█ █▀▀█ █▀▀█ █░░█ ▒█▀▀█ ▒█░▒█ 
░▒█░░ █░░█ █░░█ █▄▄█ █▄▄█ ▒█▄▄▀ ▒█▀▀█ 
░▒█░░ ▀▀▀▀ █▀▀▀ ▀░░▀ ▄▄▄█ ▒█░▒█ ▒█░▒█");
        }
    }
}