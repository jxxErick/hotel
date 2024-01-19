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
            // TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes sendo recebido
            // *IMPLEMENTE AQUI*
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
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*
            int quantidadeDeHospede = Hospedes.Count;
            return quantidadeDeHospede;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valorDaDiaria = DiasReservados * Suite.ValorDiaria;
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            bool descontoParaHospedesQueFicaramDezDias = DiasReservados >= 10;
           
            if (descontoParaHospedesQueFicaramDezDias)
            {
              valorDaDiaria = valorDaDiaria - (valorDaDiaria * 0.10M);
            }

            return valorDaDiaria;
        }
    }
}