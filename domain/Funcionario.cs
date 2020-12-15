using System;
using System.Collections.Generic;
using System.Linq;

namespace domain
{
    public class Funcionario
    {
        public Funcionario(int id, string name, JornadaDeTrabalho jornada)
        {
            Id = id;
            Name = name;
            Jornada = jornada;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public JornadaDeTrabalho Jornada { get; set; }
        public List<DataJornada> DatasJornada { get; set; }

        public void AddFolgas(List<DateTime> folgas)
        {
            foreach (DateTime folga in folgas)
            {
                DataJornada dtJornada = DatasJornada.FirstOrDefault(f => f.Data.Day == folga.Day && f.Data.Month == folga.Month && f.Data.Year == folga.Year);

                if (dtJornada.Tipo == TipoData.Folga)
                    continue;

                dtJornada.Tipo = TipoData.Folga;
            }
        }
    }
}