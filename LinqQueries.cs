using System.Reflection.Metadata;

public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //extension method
        //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

        //query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConMasDe250PagConPalabrasInAction() 
    {
        //extension method
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action")); 

        //query extresion
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool SiAlunLibroFuePublicado2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython()
    {
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> TresprimerosLibrosordenadoPorFecha()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate)
            .Take(3);
    }

    public IEnumerable<Book> TerceryCuartolibroDeMas400Pag()
    {
        return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> TresprimerosLibrosDeLaCollecion()
    {
        return librosCollection.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
    }

    public long RetornarLibrosEntre200y500()
    {
        return librosCollection.LongCount(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public DateTime FechaDePublicacionMayor()
    {
        return librosCollection.Max(p => p.PublishedDate);
    }

    public int NumeroDePagLibroMayor()
    {
        return librosCollection.Max(p=> p.PageCount);
    }

    public int SumaDeTodasLasPaginasEntre200y500()
    {
        return librosCollection.Where(p=> p.PageCount >= 0 && p.PageCount <= 500).Sum(p=> p.PageCount);
    }

    public string TitulosDeLibrosDespuesDel2015Concatenados()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2015)
            .Aggregate("", (TitulosLibros, next) =>
            {
                if (TitulosLibros != string.Empty)
                    TitulosLibros += " - " + next.Title;
                else
                    TitulosLibros += next.Title;
                return TitulosLibros;
            });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p => p.Title.Length);
    }

    public double PromedioDePaginas()
    {
        return librosCollection.Where(p=> p.PageCount>0).Average(p=> p.PageCount);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosDespuesDel2000AgrupadosPorAno()
    {
        return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p=> p.Title[0], p => p);
    }

    public IEnumerable<Book> LibrosDespuesDel2005Conmando500Pag()
    {
        var LibrosDespuesdel2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

        var LibrosConMasDe400Pag = librosCollection.Where(p => p.PageCount > 500);

        return LibrosDespuesdel2005.Join(LibrosConMasDe400Pag, p => p.Title, x => x.Title, (p, x) => p);
    }
}
