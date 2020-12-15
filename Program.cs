using System;
using System.Collections.Generic;
using System.Linq;
using domain;
using Repositories;

namespace fredyTest
{
    class Program
    {
        private static FuncionarioRepository _funcionarioRep = new FuncionarioRepository();

        static void Main(string[] args)
        {
            List<Funcionario> funcionarios = _funcionarioRep.Funcionarios();
            DateTime dataBase = new DateTime(2020, 12, 1);

            List<DateTime> folgas = new List<DateTime>()
            {
                new DateTime(2020, 12, 5),
                new DateTime(2020, 12, 12),
                new DateTime(2020, 12, 22),
                new DateTime(2020, 12, 25),
                new DateTime(2020, 12, 31)
            };

            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"  Nome: {funcionario.Name}");

                funcionario.DatasJornada = funcionario.Jornada.GerarJornada(dataBase);

                if (funcionario.Jornada.Tipo == TipoJornadaTrabalho.Seis_Um)
                {
                    funcionario.AddFolgas(folgas);
                    int dias = 0;

                    foreach (DataJornada data in funcionario.DatasJornada)
                    {
                        if (data.Tipo == TipoData.Trabalho)
                            ++dias;
                        else
                            if (dias > 6)
                            {
                                Console.WriteLine("Excedeu a quantidade de dias trabalhados em sequência");
                                break;
                            }
                            else
                                dias = 0;
                    }
                }

                foreach (DataJornada data in funcionario.DatasJornada)
                    Console.WriteLine($"  Data: {data?.Data.ToShortDateString()} { data?.Tipo.ToString() }");
                
                // Validar se a pessoa não trabalhou mais do que 6 dias em sequência, caso tenha trabalhado, 
                // imprimir "Excedeu a quantidade de dias trabalhados em sequência"

                Console.WriteLine();
            }
        }
    }
}
