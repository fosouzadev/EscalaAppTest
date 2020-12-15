using System.Collections.Generic;
using System.Threading.Tasks;
using domain;

namespace Repositories
{
    public class FuncionarioRepository
    {
        public List<Funcionario> Funcionarios()
        {
            return new List<Funcionario>{
                new Funcionario(1, "Freddy", new JornadaDeTrabalho(TipoJornadaTrabalho.Escritorio)),
                new Funcionario(2, "Felipe", new JornadaDeTrabalho(TipoJornadaTrabalho.Doze_TrintaESeis)),
                new Funcionario(3, "Katia", new JornadaDeTrabalho(TipoJornadaTrabalho.Seis_Um))
            };
        }
    }
}