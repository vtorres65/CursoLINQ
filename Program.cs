LinqQueries queries = new LinqQueries();

//Toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//Libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//Libros que tiene mas de 250 pag y tiene el titulo la palabra In Action
//ImprimirValores(queries.LibrosConMasDe250PagConPalabrasInAction());

//Todos los libros tiene Status
//Console.WriteLine($"Todos los libros tienen status?  - {queries.TodosLosLibrosTienenStatus()}");

//Si algun libro fue publicado en 2005
//Console.WriteLine($"Algun libro fue publicado en 2005? - {queries.SiAlunLibroFuePublicado2005()}");

//libros con Python
//ImprimirValores(queries.LibrosDePython());

//Los 3 primeros libros de Java
//ImprimirValores(queries.TresprimerosLibrosordenadoPorFecha());

//Tercer y cuarto libro de mas de 400pag
//ImprimirValores(queries.TerceryCuartolibroDeMas400Pag());

//tres primeros lobros filtrado con select
//ImprimirValores(queries.TresprimerosLibrosDeLaCollecion());

//Retorna los libros de 200 a 500 paginas
//Console.WriteLine($"Cantidad de libros que tiene entre 200 y 500 pag: {queries.RetornarLibrosEntre200y500()}");

//Fecha de publicacion menor de todos los libros
//Console.WriteLine($"Fecha de publicacion menor: {queries.FechaDePublicacionMenor()}");

//Numero de paginas del libro con mayor paginas
//Console.WriteLine($"El libro con mayor numero de paginas tiene: {queries.NumeroDePagLibroMayor()} paginas.");

//Suma de paginas entre 0 y 500
//Console.WriteLine($"Suma total de las paginas {queries.SumaDeTodasLasPaginasEntre200y500()}");

//Libros publicados despues del 2015
//Console.WriteLine(queries.TitulosDeLibrosDespuesDel2015Concatenados());

//Promedio de caracteres del titulo de los libros
//Console.WriteLine($"Promedio caracteres de los titulos: {queries.PromedioCaracteresTitulo()}");

//Libros publicados a partir del 2000 agrupados por ano
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAno());

//Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'A');

//Libros filtrado con la clausula join
ImprimirValores(queries.LibrosDespuesDel2005Conmando500Pag());


void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 9} {2, 11}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 9} {2, 11}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLIbros, char letra)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in ListadeLIbros[letra])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
}