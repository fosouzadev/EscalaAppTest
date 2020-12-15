using System;
using System.Collections.Generic;

namespace domain
{
    public class JornadaDeTrabalho
    {
        public JornadaDeTrabalho(TipoJornadaTrabalho tipo)
        {
            Tipo = tipo;
        }

        public TipoJornadaTrabalho Tipo { get; set; }

        public List<DataJornada> GerarJornada(DateTime dataBase)
        {
            switch (Tipo)
            {
                case TipoJornadaTrabalho.Escritorio: return JornadaEscritorio(dataBase);
                case TipoJornadaTrabalho.Doze_TrintaESeis: return JornadaDozeTrintaESeis(dataBase);
                case TipoJornadaTrabalho.Seis_Um: return JornadaSeis(dataBase);
                default: return new List<DataJornada>();
            }
        }

        private List<DataJornada> JornadaEscritorio(DateTime dataBase)
        {   // regime de escritório, onde trabalha de segunda a sexta, folgando sábados, domingos e feriados;
            int mes = dataBase.Month;

            List<DataJornada> jornada = new List<DataJornada>();
            DateTime dt = dataBase;

            do 
            {
                DataJornada dataJornada;

                if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
                    dataJornada = new DataJornada(dt, TipoData.Folga);
                else
                    dataJornada = new DataJornada(dt, TipoData.Trabalho);
                
                jornada.Add(dataJornada);

                dt = dt.AddDays(1);
                mes = dt.Month;
            } while (mes == dataBase.Month);

            return jornada;
        }

        private List<DataJornada> JornadaDozeTrintaESeis(DateTime dataBase)
        {   // 12x36, onde trabalha um dia e folga no outro
            int mes = dataBase.Month;

            List<DataJornada> jornada = new List<DataJornada>();
            DateTime dt = dataBase;
            TipoData tipoDataAnt = TipoData.Folga;

            do 
            {
                DataJornada dataJornada;

                if (tipoDataAnt == TipoData.Folga)                
                    dataJornada = new DataJornada(dt, TipoData.Trabalho);
                else
                    dataJornada = new DataJornada(dt, TipoData.Folga);
                
                tipoDataAnt = dataJornada.Tipo;
                jornada.Add(dataJornada);

                dt = dt.AddDays(1);
                mes = dt.Month;
            } while (mes == dataBase.Month);

            return jornada;
        }

        private List<DataJornada> JornadaSeis(DateTime dataBase)
        {   // 6x1, onde trabalha todos os dias sem exceção e tem direito a 5 folgas no mês que são distribuídas posteriormente;
            int mes = dataBase.Month;

            List<DataJornada> jornada = new List<DataJornada>();
            DateTime dt = dataBase;

            do 
            {
                DataJornada dataJornada = new DataJornada(dt, TipoData.Trabalho);

                jornada.Add(dataJornada);

                dt = dt.AddDays(1);
                mes = dt.Month;
            } while (mes == dataBase.Month);

            return jornada;
        }
    }
}