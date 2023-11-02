using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoTopayRH
{
    class Funcionarios
    {
        private Dictionary<int, Funcionario> funcionarios = new Dictionary<int, Funcionario>();

        public Funcionarios()
        {
            // Adicionar informações de funcionários ao dicionário.
            funcionarios.Add(1, new Funcionario("Lucas Gregory", 20, "16425", 5000.0, "LucasGregory@TopayRH.com.br", "Senha1234", "Gerente de Projeto"));
            funcionarios.Add(2, new Funcionario("Otavio", 25, "14523", 6000.0, "OtavioSoares@TopayRH.com.br", "Senha123", "Gerente Projeto Pleno"));
            funcionarios.Add(3, new Funcionario("Caio", 19, "12453", 3000.0, "CaioMelo@TopayRH.com.br", "Senha12345","Analista Junior"));
        }

        public Funcionario ObterFuncionarioPorNome(string nome)
        {
            return funcionarios.Values.FirstOrDefault(funcionario => funcionario.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }


        public List<Funcionario> ObterFuncionarios()
        {
            return funcionarios.Values.ToList();
        }

        public void MostrarInformacoesFuncionario(int funcionarioId)
        {
            if (funcionarios.ContainsKey(funcionarioId))
            {
                Funcionario funcionario = funcionarios[funcionarioId];
                Console.WriteLine("Nome: " + funcionario.Nome);
                Console.WriteLine("Matrícula: " + funcionario.Matricula);
                Console.WriteLine("Salário: " + funcionario.Salario);
                Console.WriteLine("Email: " + funcionario.Email);
                Console.WriteLine("Cargo: "+ funcionario.Cargo);

            }
            else
            {
                Console.WriteLine("Funcionário não encontrado.");
            }
        }

        public bool ValidarLogin(string email, string senha)
        {
            foreach (var funcionario in funcionarios.Values)
            {
                if (funcionario.Email == email && funcionario.Senha == senha)
                {
                    return true; // Login bem-sucedido
                }
            }
            return false; // Login sem sucesso
        }

        public void CadastrarColaborador(string nome, int matricula, int idade, double salario, string email, string senha, string cargo)
        {
            // Gere um novo ID para o colaborador
            int novoId = funcionarios.Keys.Max() + 1;

            // Crie um novo colaborador e adicione ao dicionário
            Funcionario novoColaborador = new Funcionario(nome, idade, matricula.ToString(), salario, email, senha,cargo);
            funcionarios.Add(novoId, novoColaborador);

        }
    }


    class Funcionario
    {
        public string Nome { get; }
        public int Idade { get; }
        public string Matricula { get; }
        public double Salario { get; }
        public string Email { get; }
        public string Senha { get; }
        public string Cargo { get; set; }
        public double DescontoINSS { get; set; }


        public Funcionario(string nome, int idade, string matricula, double salario, string email, string senha, string cargo)
        {
            Nome = nome;
            Idade = idade;
            Matricula = matricula;
            Salario = salario;
            Email = email;
            Senha = senha;
            Cargo = cargo;
        }
    }
}
