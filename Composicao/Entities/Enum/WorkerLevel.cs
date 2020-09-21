namespace Composicao.Entities.Enum //Não é obrigatório manter o mesmo nome do namespace com o caminho das pastas, mas geralmente é bom manter para facilitar a localização das classes no projeto
{
    enum WorkerLevel : int //Classe enumeradora para definir os níveis do trabalhador, e esse tipo deriva (: int) do tipo int
    {
        Junior = 0,
        MidLevel = 1,
        Senior = 2
    }
}
