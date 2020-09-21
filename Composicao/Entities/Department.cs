using System;
using System.Collections.Generic;
using System.Text;

namespace Composicao.Entities
{
    class Department
    {
        public string Name { get; set; } //Propriedade responsável por armazenar os departamentos

        public Department() //Construtor Padrão
        {

        }

        public Department(string name) //Construtor para receber o nome como argumento
        {
            Name = name;
        }

    }
}
