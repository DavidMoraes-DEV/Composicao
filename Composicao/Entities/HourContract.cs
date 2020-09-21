using System;

namespace Composicao.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; } //Propriedade para as datas do contrato
        public double ValuePerHour { get; set; } //Propriedade para os valores por hora
        public int Hours { get; set; } //Propriedade para a duração em horas do contrato

        public HourContract() //Construtor padrão
        {
        }

        public HourContract(DateTime date, double valuePerHour, int hours) //Construtor com os parâmetros data, valor por hora e horas
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue() //Método responsável por retornar o valor total do contrato
        {
            return Hours * ValuePerHour;
        }
    }
}
