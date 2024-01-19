using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospedagemDeHotel.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool quantidadeDeHospede = hospedes.Count <= Suite.Capacidade;
            if (quantidadeDeHospede)
            {
                Hospedes = hospedes;
            }
            else
            {
               throw new ArgumentOutOfRangeException(nameof(hospedes), $"A quantidade de hospedes ({hospedes.Count}) excede a capacidade da suíte que é de {Suite.Capacidade}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeDeHospede = Hospedes.Count;
            return quantidadeDeHospede;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valorDaDiaria = DiasReservados * Suite.ValorDiaria;

            bool descontoParaHospedesQueFicaramDezDias = DiasReservados >= 10;
           
            if (descontoParaHospedesQueFicaramDezDias)
            {
              valorDaDiaria = valorDaDiaria - (valorDaDiaria * 0.10M);
            }

            return valorDaDiaria;
        }
    }
}