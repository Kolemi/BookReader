using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookReader.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BookReader.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookReaderContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookReaderContext>>()))
            {
                // Look for any movies.
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "Harry Potter i Kamień Filozoficzny",
                        Description = "Harry po pełnym przygód roku w Hogwarcie spędza nudne " +
                        "wakacje u Dursleyów i z utęsknieniem wyczekuje powrotu do szkoły. " +
                        "Sprawy jednak znacznie się komplikują, gdy pewnego dnia odwiedza go tajemniczy przybysz i ostrzega przed… " +
                        "powrotem do Szkoły Magii i Czarodziejstwa, gdzie ma dojść do strasznych wydarzeń. Czy Harry posłucha ostrzeżenia? " +
                        "Co złego ma się wydarzyć w Hogwarcie? Jakie tajemnice skrywa rodzina Malforya? " +
                        "I najważniejsze – czym jest i gdzie znajduje się tytułowa Komnata Tajemnic?" +
                        "Nowe wydanie różni się od poprzednich nie tylko okładką, ale i wnętrzem – " +
                        "po raz pierwszy na początku każdego tomu pojawi się mapka Hogwartu i okolic, " +
                        "a początki rozdziałów ozdobione będą specjalnymi gwiazdkami.",
                        Author = "J.K. Rowling",
                        ReleaseDate = DateTime.Parse("2020-9-22"),
                        CategoryID = 1,
                        Price = 30.99M
                    },

                    new Book
                    {
                        Title = "Hobbit",
                        Description = "Pełne magii i przygód wspaniałe preludium do „Władcy Pierścieni”." +
                        "Wydanie ilustrowane z genialnymi ilustracjami Alana Lee, które zainspirowały twórców kinowego przeboju." +
                        "Bilbo Baggins to hobbit, który lubi wygodne, pozbawione niespodzianek życie, rzadko podróżując dalej niż do swojej piwnicy." +
                        "Jego błogi spokój zostaje jednak zakłócony, gdy pewnego na jego progu pojawia się " +
                        "czarodziej Gandalf z gromadą krasnoludów, by porwać go na prawdziwą przygodę." +
                        "Wszyscy wyruszają po wielkie skarby strzeżone przez Smauga Wspaniałego, " +
                        "wielkiego i bardzo niebezpiecznego smoka.Bilbo niechętnie dołącza do ich misji, " +
                        "nie zdając sobie sprawy, że w drodze do Samotnej Góry spotka zarówno magiczny pierścień, " +
                        "jak i przerażające stworzenie zwane Gollumem." +
                        "„Oszałamiająca opowieść o wielkiej przygodzie, wypełniona napięciem i zaprawiona subtelnym humorem, któremu nie sposób się oprzeć”.",
                        Author = "J.R.R. Tolkien",
                        ReleaseDate = DateTime.Parse("2020-9-22"),
                        CategoryID = 1,
                        Price = 50.99M
                    }
                );

                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Romans"

                    },

                    new Category
                    {
                         Name = "Kryminał"

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
