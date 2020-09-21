using Composicao.Entities.Enum; //Declaração para ser possível utilizar as propriedades da classe Enum
using System.Collections.Generic; //NameEspace da classe List

namespace Composicao.Entities
{
    class Worker
    {
        public string Name { get; set; } //Propriedade para o nome do trabalhador
        public WorkerLevel Level { get; set; } //Propriedade para o nível do trabalhador
        public double BaseSalary { get; set; } //Propriedade para a Base salarial do trabalhador
        public Department Department { get; set; } /*Propriedade para o Departamento(****Aqui que é aplicado a composição de objetos, ou seja, uma associação entre Worker e Department.
        Isso significa que dentro dessa classe Worker tenho que declarar uma propriedade do tipo Department para obter uma associação entre os dados do trabalhador e seu departamento
        que pertence ao instânciar na memória(Verificar no material didático o diagrama UML de objetos para facilitar na compreenção)).*/
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); //Propriedade em lista para armazenar os contratos do trabalhador(Já intanciando a lista para garantir que ela não seja nula.)
        
        public Worker() //Propriedade padrão
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) //Construtor com os parâmetros necessários(sem incluir as associoações para muitos(Contracts), pois não é usual passar uma lista instanciada no construtor de um objeto. Essa lista irá começar vazia e será adicionado os objetos conforme a necessidade)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContract (HourContract contract) //Método para adicionar um contrato ao trabalhador(Recebendo como parâmetro de entrada um contrato para ai ser adicionado dentro da lista de contratos do trabalhador
        {
            Contracts.Add(contract);
        }

        public void RemoveContract (HourContract contract) //Método para remover um contrato da lista de contratos do trabalhador.
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month) //Método para calcular o ganho do trabalhador num dado ano e mes especificado como parâmetros de entrada, para melhor compreensão verificar o diagrama UML de objetos que mostra o comportamento dos objetos dentro da memória
        {
            double sum = BaseSalary;
            foreach(HourContract contract in Contracts) //Para que seja possível calcular a soma dos contratos de uma dado mes e ano devo percorrer a lista de contratos.
            {
                if(contract.Date.Year == year && contract.Date.Month == month) //acumulando seu valores quando o mes e ano do contrato for compatível com o dado de entrada especificado year e Month.
                {
                    sum += contract.TotalValue(); //.TotalValue é a operação que retornará o valor total do contrato em questão.
                }
            }
            return sum;
        }
    }
}
