namespace Arnald.Series;
using static System.Console;
internal class NewBaseType
{
    static SerieRepositorio repositorio = new SerieRepositorio();

    

    private static void AtualizarSeries()
    {
        Write("Digite o id da série: ");
        int indiceSeries = int.Parse(ReadLine());

        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(ReadLine());

        Write("Digite o Título da Série: ");
        string entradaTitulo = ReadLine();

        Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(ReadLine());

        Write("Digite a Descrição da Série: ");
        string entradaDescricao = ReadLine();

        Series atualizaSeries = new Series(id: indiceSeries,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Atualiza(indiceSeries, atualizaSeries);        
    }

    private static void ExcluirSeries()
    {
        Write("Digite o id da série: ");
        int indiceSeries = int.Parse(ReadLine());

        repositorio.Exclui(indiceSeries);
    }

    private static void InserirSeries()
    {
        WriteLine("Inserir nova série");

        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
        // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(ReadLine());

        Write("Digite o Título da Série: ");
        string entradaTitulo = ReadLine();

        Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(ReadLine());

        Write("Digite a Descrição da Série: ");
        string entradaDescricao = ReadLine();

        Series novaSeries = new Series(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);

        repositorio.Insere(novaSeries);
    }
    private static void ListarSeries()
    {
        WriteLine("Listar séries");

        var lista = repositorio.Lista();

        if (lista.Count == 0)
        {
            WriteLine("Nenhuma série cadastrada.");
            return;
        }

        foreach (var Series in lista)
        {
            var excluido = Series.retornaExcluido();

            WriteLine("#ID {0}: - {1} {2}", Series.retornaId(), Series.retornaTitulo(), (excluido ? "*Excluído*" : ""));
        }
    }
    static void Main(string[] args)

    {
        

        Tipo();



        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != "X")
        {
            switch (opcaoUsuario)
            {
                case "1":
                    ListarSeries();
                    break;
                case "2":
                    InserirSeries();
                    break;
                case "3":
                    AtualizarSeries();
                    break;
                case "4":
                    ExcluirSeries();
                    break;
                case "5":
                    VisualizarSeries();
                    break;
                case "C":
                    Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }

        WriteLine("Obrigado por utilizar nossos serviços.");
        ReadLine();
    }

    private static void Tipo(){
        WriteLine();
        WriteLine("DIO Séries a seu dispor!!!");
        WriteLine("Informe a opção desejada:");

        WriteLine ("1- Filme");
        WriteLine ("2- Série");
    }
    private static string ObterOpcaoUsuario()
    {
        WriteLine();
        WriteLine("DIO Séries a seu dispor!!!");
        WriteLine("Informe a opção desejada:");

        WriteLine("1- Listar séries");
        WriteLine("2- Inserir nova série");
        WriteLine("3- Atualizar série");
        WriteLine("4- Excluir série");
        WriteLine("5- Visualizar série");
        WriteLine("C- Limpar Tela");
        WriteLine("X- Sair");
        WriteLine();

        string opcaoUsuario = ReadLine().ToUpper();
        WriteLine();
        return opcaoUsuario;
    }

    private static void VisualizarSeries()
    {
        Write("Digite o id da série: ");
        int indiceSeries = int.Parse(ReadLine());

        var Series = repositorio.RetornaPorId(indiceSeries);

        WriteLine(Series);
    }
}

class Program : NewBaseType
{
}
