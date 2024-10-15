var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// dotnet new sln --output NomeDaSolução
// dotnet new web --name NomeDoProjeto
// dotnet sln add NomeDoProjeto
// ver localhost e criar o teste.http
// GET: http://localhost:****
// Criar pasta de modelos e criar as classes
// Adiionar pacotes do sqlite
// dotnet add package Microsoft.EntityFrameworkCore.Sqlite
// dotnet add package Microsoft.EntityFrameworkCore.Design
// Criar classe AppDataContext
// using Microsoft.EntityFrameworkCore;
// public class AppDbContext : DbContext
// {
//     public DbSet<Produto> Produtos { get; set; }
//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseSqlite("Data Source=nomeDoSeuBanco.db");
//     }
// }
// Rodar comandos da migração
// dotnet ef migrations add InitialCreate
// dotnet ef database update


// EXEMPLO RELCIONAMENTO ENTRE TABELAS

// public class Autor
// {
//     public int AutorId { get; set; } // Chave primária
//     public string Nome { get; set; } // Nome do autor

//     // Navegação para os livros
//     public ICollection<Livro> Livros { get; set; } = new List<Livro>();
// }

// public class Livro
// {
//     public int LivroId { get; set; } // Chave primária
//     public string Titulo { get; set; } // Título do livro
//     public int AutorId { get; set; } // Chave estrangeira

//     // Navegação para o autor
//     public Autor Autor { get; set; }
// }

// using Microsoft.EntityFrameworkCore;

// public class ApplicationDbContext : DbContext
// {
//     public DbSet<Autor> Autores { get; set; }
//     public DbSet<Livro> Livros { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//     {
//         optionsBuilder.UseSqlite("Data Source=livros.db"); // Caminho do arquivo do SQLite
//     }

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Livro>()
//             .HasOne(l => l.Autor) // Define a relação entre Livro e Autor
//             .WithMany(a => a.Livros) // Define a relação reversa
//             .HasForeignKey(l => l.AutorId); // Chave estrangeira
//     }
// }

// COMANDOS DE MIGRAÇÃO

// using (var contexto = new ApplicationDbContext())
// {
//     var autor = new Autor { Nome = "George Orwell" };
//     var livro = new Livro { Titulo = "1984", Autor = autor };

//     contexto.Autores.Add(autor);
//     contexto.Livros.Add(livro);
//     contexto.SaveChanges();
// }

// using (var contexto = new ApplicationDbContext())
// {
//     var autoresComLivros = contexto.Autores
//         .Include(a => a.Livros)
//         .ToList();

//     foreach (var autor in autoresComLivros)
//     {
//         Console.WriteLine($"{autor.Nome} escreveu:");
//         foreach (var livro in autor.Livros)
//         {
//             Console.WriteLine($"- {livro.Titulo}");
//         }
//     }
// }



//RELAÇÃO UM PRA MUITOS
// modelBuilder.Entity<Livro>()
//     .HasOne(l => l.Autor) 
//     .WithMany(a => a.Livros) 
//     .HasForeignKey(l => l.AutorId);


//RELAÇÃO UM PRA UM
// modelBuilder.Entity<Pessoa>()
//     .HasOne(p => p.Endereco) 
//     .WithOne(e => e.Pessoa) 
//     .HasForeignKey<Endereco>(e => e.PessoaId);


//RELAÇÃO MUITOS PRA MUITOS
// modelBuilder.Entity<EstudanteCurso>()
//     .HasKey(ec => new { ec.EstudanteId, ec.CursoId });

// modelBuilder.Entity<EstudanteCurso>()
//     .HasOne(ec => ec.Estudante)
//     .WithMany(e => e.EstudanteCursos)
//     .HasForeignKey(ec => ec.EstudanteId); 

// modelBuilder.Entity<EstudanteCurso>()
//     .HasOne(ec => ec.Curso)
//     .WithMany(c => c.EstudanteCursos)
//     .HasForeignKey(ec => ec.CursoId); 
app.Run();
