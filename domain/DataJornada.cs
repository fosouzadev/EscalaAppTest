using System;

namespace domain
{
    public class DataJornada
    {
        public DataJornada(DateTime data, TipoData tipo)
        {
            Data = data;
            Tipo = tipo;
        }

        public DateTime Data { get; set; }
        public TipoData Tipo { get; set; }
    }
}