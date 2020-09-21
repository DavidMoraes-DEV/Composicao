using Composicao.Entities; 
using Composicao.Entities.Enum;
using System;
using System.Globalization;

namespace Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            /*COMPOSIÇÃO: É um tipo de associação que permite que um objeto contenha outro
             
            relação "tem um" ou "tem-vários"

            VANTAGENS:
            - Organização: divisão de responsabilitades
            - Coesão
            - Flexibilidade
            - Reuso

            Nota: Embora o símbolo UML para composição (todo-parte) seja o diamante preto, neste contexto estamos chamando de composição qualquer associação do tipo "tem-um" e "tem-vários"             
            */

            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //Recebe o nível do funcionário como string e é convertida para um objeto do tipo WorkerLevel que é a enumeração.
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName); //Instanciação do objeto Department. Usando a sobre carga que utiliza apenas o Name.

            Worker worker = new Worker(name, level, baseSalary, dept); //Instanciação do objeto Worker com os dados do trabalhador nas variáveis temporárias (name, level, baseSalary, dept).

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i<=n; i++) //Estrutura de repetição para ler e instânciar os dados de contrato
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours); //Instanciação do contrato
                worker.AddContract(contract); //Adiciona o contrato instanciado acima para a lista de contratos do trabalhador instanciado anteriormente.
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine(); //Variável temporária para ler a data como string
            int month = int.Parse(monthAndYear.Substring(0, 2)); //Função .Substring para recortar a string e armazenar apenas o mes, limitando o recorte pelas posição definidas na Substring.
            int year = int.Parse(monthAndYear.Substring(3)); //Função .Substring para recortar a string e armazenar dessa vez apenas o ano.

            Console.WriteLine("Name: " + worker.Name); //Mostra o nome do funcionário
            Console.WriteLine("Department: " + worker.Department.Name); //Mostra o nome do departamento associado a esse trabalhador
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)); //Mostra o ganho total desse trabalhador no mes e ano definido anteriormente. levando em consideração o total de contratos e horas deles junto com seu salário base.
        }
    }
}
/*Exercicio Exemplo: Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). 
 Depois, solicitar do usuário um mês e mostrar qual foi o salário do funcionário nesse mês, conforme exemplo:
Exemplo:

Nome do departamento: Design

Entre com os dados do trabalhador:
Nome: Alex
Nível (Junior/Intermediário/Senior: Intermediario.
Salário Base: 1200.00

Quantos contratos para esse trabalhador? 3

Entre com os dados do #1 contrato:
Data (DD/MM/YYYY): 20/08/2018
Valor por hora: 50.00
Duração (horas): 20

Entre com os dados do #2 contrato:
Data (DD/MM/YYYY): 13/06/2018
Valor por hora: 30.00
Duração (horas): 18

Entre com os dados do #3 contrato:
Data (DD/MM/YYYY): 25/08/2018
Valor por hora: 80.00
Duração (horas): 10

Entre com o mês e o ano para calcular quanto o funcionário recebeu nesse mês e ano (MM/YYYY): 08/2018

Nome: Alex
Departamento: Design
Ganhor para 08/2018: 3000.00

 */