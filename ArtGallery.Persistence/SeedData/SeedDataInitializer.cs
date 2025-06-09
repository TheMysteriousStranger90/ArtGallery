using ArtGallery.Domain.Entities;
using ArtGallery.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.SeedData
{
    public static class SeedDataInitializer
    {
        public static void ContextSeed(ModelBuilder modelBuilder)
        {
            var russia = new Country
            {
                Id = Guid.Parse("8c6aeae0-5c40-4085-8993-7d7b5db21106"),
                Name = "Russia",
                Code = "RU",
                CreatedDate = DateTime.UtcNow
            };

            var italy = new Country
            {
                Id = Guid.Parse("8c6aeae0-5c40-4085-8993-7d7b5db21200"),
                Name = "Italy",
                Code = "IT",
                CreatedDate = DateTime.UtcNow
            };

            modelBuilder.Entity<Country>().HasData(russia, italy);
            
            var moscow = new City
            {
                Id = Guid.Parse("9c6aeae0-5c40-4085-8993-7d7b5db21107"),
                Name = "Moscow",
                CountryId = russia.Id,
                CreatedDate = DateTime.UtcNow
            };

            var stPetersburg = new City
            {
                Id = Guid.Parse("9c6aeae0-5c40-4085-8993-7d7b5db21108"),
                Name = "Saint Petersburg",
                CountryId = russia.Id,
                CreatedDate = DateTime.UtcNow
            };

            var florence = new City
            {
                Id = Guid.Parse("9c6aeae0-5c40-4085-8993-7d7b5db21201"),
                Name = "Florence",
                CountryId = italy.Id,
                CreatedDate = DateTime.UtcNow
            };

            var rome = new City
            {
                Id = Guid.Parse("9c6aeae0-5c40-4085-8993-7d7b5db21202"),
                Name = "Rome",
                CountryId = italy.Id,
                CreatedDate = DateTime.UtcNow
            };

            modelBuilder.Entity<City>().HasData(moscow, stPetersburg, florence, rome);
            
            var tretyakovGallery = new Museum
            {
                Id = Guid.Parse("bc6aeae0-5c40-4085-8993-7d7b5db21109"),
                Name = "The State Tretyakov Gallery",
                Description =
                    "The State Tretyakov Gallery is an art gallery in Moscow, Russia, the foremost depository of Russian fine art in the world.",
                Address = "Lavrushinsky Ln, 10, Moscow, Russia, 119017",
                WebsiteUrl = "https://www.tretyakovgallery.ru/en/",
                CityId = moscow.Id,
                CreatedDate = DateTime.UtcNow
            };

            var russianMuseum = new Museum
            {
                Id = Guid.Parse("bc6aeae0-5c40-4085-8993-7d7b5db21110"),
                Name = "The State Russian Museum",
                Description =
                    "The State Russian Museum is the world's largest depository of Russian fine art. It is also one of the largest museums in the country.",
                Address = "Inzhenernaya St, 4, St Petersburg, Russia, 191186",
                WebsiteUrl = "https://rusmuseum.ru/en/",
                CityId = stPetersburg.Id,
                CreatedDate = DateTime.UtcNow
            };

            var uffizi = new Museum
            {
                Id = Guid.Parse("bc6aeae0-5c40-4085-8993-7d7b5db21203"),
                Name = "Uffizi Gallery",
                Description =
                    "The Uffizi Gallery is a prominent art museum located adjacent to the Piazza della Signoria in the Historic Centre of Florence in the region of Tuscany, Italy.",
                Address = "Piazzale degli Uffizi, 6, 50122 Firenze FI, Italy",
                WebsiteUrl = "https://www.uffizi.it/en",
                CityId = florence.Id,
                CreatedDate = DateTime.UtcNow
            };

            var vaticanMuseum = new Museum
            {
                Id = Guid.Parse("bc6aeae0-5c40-4085-8993-7d7b5db21204"),
                Name = "Vatican Museums",
                Description =
                    "The Vatican Museums are the public museums of the Vatican City. They display works from the immense collection amassed by the Catholic Church and the papacy throughout the centuries.",
                Address = "00120 Vatican City",
                WebsiteUrl = "https://www.museivaticani.va/",
                CityId = rome.Id,
                CreatedDate = DateTime.UtcNow
            };

            modelBuilder.Entity<Museum>().HasData(tretyakovGallery, russianMuseum, uffizi, vaticanMuseum);
            
            var mythological = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21111"),
                Name = "Mythological Art",
                Description = "Art depicting scenes from mythology or folklore",
                CreatedDate = DateTime.UtcNow
            };

            var landscape = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21112"),
                Name = "Landscape",
                Description = "Art depicting natural scenery, such as mountains, valleys, trees, rivers, and forests",
                CreatedDate = DateTime.UtcNow
            };

            var seascape = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21113"),
                Name = "Seascape",
                Description = "Art depicting the sea or maritime scenes",
                CreatedDate = DateTime.UtcNow
            };

            var symbolism = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21114"),
                Name = "Symbolism",
                Description = "Art that emphasizes the expression of ideas through symbols",
                CreatedDate = DateTime.UtcNow
            };

            var renaissance = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21205"),
                Name = "Renaissance",
                Description = "Art from the Renaissance period characterized by realistic depiction and classical themes",
                CreatedDate = DateTime.UtcNow
            };

            var religious = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21206"),
                Name = "Religious Art",
                Description = "Art depicting religious themes and biblical scenes",
                CreatedDate = DateTime.UtcNow
            };

            var portrait = new Genre
            {
                Id = Guid.Parse("cc6aeae0-5c40-4085-8993-7d7b5db21207"),
                Name = "Portrait",
                Description = "Art depicting individual persons or groups of people",
                CreatedDate = DateTime.UtcNow
            };

            modelBuilder.Entity<Genre>().HasData(mythological, landscape, seascape, symbolism, renaissance, religious, portrait);

            // Seed Tags
            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21115"),
                    Name = "Russian Art",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21116"),
                    Name = "19th Century",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21117"),
                    Name = "Early 20th Century",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21118"),
                    Name = "Romanticism",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21119"),
                    Name = "Folklore",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21120"),
                    Name = "Sea",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21121"),
                    Name = "Spring",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21208"),
                    Name = "Italian Art",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21209"),
                    Name = "Renaissance",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21210"),
                    Name = "Classical",
                    CreatedDate = DateTime.UtcNow
                },
                new Tag
                {
                    Id = Guid.Parse("dc6aeae0-5c40-4085-8993-7d7b5db21211"),
                    Name = "Baroque",
                    CreatedDate = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Tag>().HasData(tags);

            // Seed Artists (Russian + Italian)
            var vasnetsov = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21122"),
                FirstName = "Viktor",
                LastName = "Vasnetsov",
                BirthDate = new DateTime(1848, 5, 15),
                DeathDate = new DateTime(1926, 7, 23),
                Nationality = "Russian",
                CreatedDate = DateTime.UtcNow
            };

            var vrubel = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21123"),
                FirstName = "Mikhail",
                LastName = "Vrubel",
                BirthDate = new DateTime(1856, 3, 17),
                DeathDate = new DateTime(1910, 4, 14),
                Nationality = "Russian",
                CreatedDate = DateTime.UtcNow
            };

            var aivazovsky = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21124"),
                FirstName = "Ivan",
                LastName = "Aivazovsky",
                BirthDate = new DateTime(1817, 7, 29),
                DeathDate = new DateTime(1900, 5, 5),
                Nationality = "Russian",
                CreatedDate = DateTime.UtcNow
            };

            var savrasov = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21125"),
                FirstName = "Alexei",
                LastName = "Savrasov",
                BirthDate = new DateTime(1830, 5, 24),
                DeathDate = new DateTime(1897, 10, 8),
                Nationality = "Russian",
                CreatedDate = DateTime.UtcNow
            };

            // Italian Artists
            var daVinci = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21212"),
                FirstName = "Leonardo",
                LastName = "da Vinci",
                BirthDate = new DateTime(1452, 4, 15),
                DeathDate = new DateTime(1519, 5, 2),
                Nationality = "Italian",
                CreatedDate = DateTime.UtcNow
            };

            var michelangelo = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21213"),
                FirstName = "Michelangelo",
                LastName = "Buonarroti",
                BirthDate = new DateTime(1475, 3, 6),
                DeathDate = new DateTime(1564, 2, 18),
                Nationality = "Italian",
                CreatedDate = DateTime.UtcNow
            };

            var botticelli = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21214"),
                FirstName = "Sandro",
                LastName = "Botticelli",
                BirthDate = new DateTime(1445, 3, 1),
                DeathDate = new DateTime(1510, 5, 17),
                Nationality = "Italian",
                CreatedDate = DateTime.UtcNow
            };

            var caravaggio = new Artist
            {
                Id = Guid.Parse("ec6aeae0-5c40-4085-8993-7d7b5db21215"),
                FirstName = "Michelangelo Merisi",
                LastName = "da Caravaggio",
                BirthDate = new DateTime(1571, 9, 29),
                DeathDate = new DateTime(1610, 7, 18),
                Nationality = "Italian",
                CreatedDate = DateTime.UtcNow
            };

            modelBuilder.Entity<Artist>().HasData(vasnetsov, vrubel, aivazovsky, savrasov, daVinci, michelangelo, botticelli, caravaggio);

            // Seed Biographies (Russian + Italian)
            var biographies = new List<Biography>
            {
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21126"),
                    Content =
                        "Viktor Mikhailovich Vasnetsov was a Russian painter who specialized in mythological and historical subjects. He is considered the co-founder of Russian folklorist and romantic nationalistic painting and a key figure in the Russian revivalist movement. His notable works include After Prince Igor's Battle with the Polovtsy, Knight at the Crossroads, Bogatyrs, and Alyonushka.",
                    ShortDescription = "One of the key figures in the Russian revivalist movement",
                    References = "Korotkevich, V.N. Viktor Vasnetsov: The Artist's Work. Leningrad, 1962.",
                    ArtistId = vasnetsov.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21127"),
                    Content =
                        "Mikhail Aleksandrovich Vrubel was a Russian painter who specialized in symbolist paintings of mythological themes. His contemporaries often saw him as strange and mentally unstable due to his unique style of painting. At the time of his death, Vrubel was among the most controversial painters in Russian art. His innovative art is now considered a bridge connecting the traditional art of the 19th century with the modernism of the 20th century.",
                    ShortDescription = "A Russian symbolist painter known for his unusual style and technique",
                    References = "Gomberg-Verzhbinskaia, E.P. Vrubel. Moscow, 1959.",
                    ArtistId = vrubel.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21128"),
                    Content =
                        "Ivan Konstantinovich Aivazovsky was a Russian Romantic painter who is considered one of the greatest masters of marine art. He was born into an Armenian family in the town of Feodosia in Crimea and was mostly known for his seascapes, which constitute more than half of his paintings. During his almost 60-year career, he created around 6,000 paintings, making him one of the most prolific artists of his time.",
                    ShortDescription = "One of the greatest masters of marine art in history",
                    References =
                        "Caffiero, G., Samarine, I. Seas, Cities & Dreams: The Paintings of Ivan Aivazovsky. London, 2000.",
                    ArtistId = aivazovsky.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21129"),
                    Content =
                        "Alexei Kondratyevich Savrasov was a Russian landscape painter and creator of the 'mood landscape' genre. He is credited with developing the lyrical landscape style, and his painting The Rooks Have Come Back (1871) is considered one of the most significant works of Russian landscape painting. Savrasov's life was marked by personal tragedy and alcoholism in his later years, but his influence on Russian landscape painting was immense.",
                    ShortDescription = "Founder of the lyrical landscape style in Russian painting",
                    References = "Novouspensky, N. Alexei Savrasov. Leningrad, 1982.",
                    ArtistId = savrasov.Id,
                    CreatedDate = DateTime.UtcNow
                },
                // Italian Artists Biographies
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21216"),
                    Content =
                        "Leonardo da Vinci was an Italian polymath of the High Renaissance who was active as a painter, draughtsman, engineer, scientist, theorist, sculptor and architect. While his fame initially rested on his achievements as a painter, he also became known for his notebooks, in which he made drawings and notes on science and invention. These involved a variety of subjects including anatomy, astronomy, botany, cartography, painting, and paleontology.",
                    ShortDescription = "Renaissance polymath and painter of the Mona Lisa",
                    References = "Kemp, Martin. Leonardo da Vinci: The Marvellous Works of Nature and Man. Oxford, 2006.",
                    ArtistId = daVinci.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21217"),
                    Content =
                        "Michelangelo di Lodovico Buonarroti Simoni was an Italian sculptor, painter, architect, and poet of the High Renaissance. Born in the Republic of Florence, his work exerted an unparalleled influence on the development of Western art. Considered the greatest living artist during his lifetime, he has since been described as one of the greatest artists of all time.",
                    ShortDescription = "Renaissance master sculptor and painter of the Sistine Chapel",
                    References = "Wallace, William E. Michelangelo: The Artist, the Man and His Times. Cambridge, 2010.",
                    ArtistId = michelangelo.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21218"),
                    Content =
                        "Alessandro di Mariano di Vanni Filipepi, known as Sandro Botticelli, was an Italian painter of the Early Renaissance. Botticelli's posthumous reputation suffered until the late 19th century, when he was rediscovered by the Pre-Raphaelites who stimulated a reappraisal of his work. Since then, his paintings have been seen to represent the linear grace of Early Renaissance painting.",
                    ShortDescription = "Early Renaissance painter famous for The Birth of Venus",
                    References = "Lightbown, Ronald. Sandro Botticelli: Life and Work. London, 1989.",
                    ArtistId = botticelli.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Biography
                {
                    Id = Guid.Parse("fc6aeae0-5c40-4085-8993-7d7b5db21219"),
                    Content =
                        "Michelangelo Merisi da Caravaggio was an Italian painter active in Rome for most of his artistic life. During the final four years of his life he moved between Naples, Malta, and Sicily until his death. His paintings have been characterized by art critics as combining a realistic observation of the human state, both physical and emotional, with a dramatic use of lighting.",
                    ShortDescription = "Baroque painter renowned for his revolutionary use of light and shadow",
                    References = "Langdon, Helen. Caravaggio: A Life. New York, 1998.",
                    ArtistId = caravaggio.Id,
                    CreatedDate = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Biography>().HasData(biographies);

            // Seed Artist Images (Russian + Italian) - Fixed URLs
            var artistImages = new List<ArtistImage>
            {
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg/256px-Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg",
                    IsMain = true,
                    PublicId = "artist_vasnetsov",
                    ArtistId = vasnetsov.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7f/Vrubel_Self-Portrait_1882.jpg/256px-Vrubel_Self-Portrait_1882.jpg",
                    IsMain = true,
                    PublicId = "artist_vrubel",
                    ArtistId = vrubel.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b5/Aivazovsky_-_Self-portrait_1874.jpg/256px-Aivazovsky_-_Self-portrait_1874.jpg",
                    IsMain = true,
                    PublicId = "artist_aivazovsky",
                    ArtistId = aivazovsky.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9f/Alexey_Savrasov.jpg/256px-Alexey_Savrasov.jpg",
                    IsMain = true,
                    PublicId = "artist_savrasov",
                    ArtistId = savrasov.Id,
                    CreatedDate = DateTime.UtcNow
                },
                // Italian Artists Images
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21220"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Leonardo_self.jpg/256px-Leonardo_self.jpg",
                    IsMain = true,
                    PublicId = "artist_davinci",
                    ArtistId = daVinci.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21221"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5e/Miguel_%C3%81ngel%2C_por_Daniele_da_Volterra_%28detalle%29.jpg/256px-Miguel_%C3%81ngel%2C_por_Daniele_da_Volterra_%28detalle%29.jpg",
                    IsMain = true,
                    PublicId = "artist_michelangelo",
                    ArtistId = michelangelo.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21222"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Sandro_Botticelli_083.jpg/256px-Sandro_Botticelli_083.jpg",
                    IsMain = true,
                    PublicId = "artist_botticelli",
                    ArtistId = botticelli.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21223"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Bild-Ottavio_Leoni%2C_Caravaggio.jpg/256px-Bild-Ottavio_Leoni%2C_Caravaggio.jpg",
                    IsMain = true,
                    PublicId = "artist_caravaggio",
                    ArtistId = caravaggio.Id,
                    CreatedDate = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<ArtistImage>().HasData(artistImages);

            // Seed Paintings (Russian + Italian) - Fixed URLs
            var paintings = new List<Painting>
            {
                // Russian paintings with fixed URLs
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                    Title = "Bogatyrs",
                    Description =
                        "Also known as Three Bogatyrs, this painting depicts three of the most legendary bogatyrs (medieval Russian knights): Dobrynya Nikitich, Ilya Muromets and Alyosha Popovich. They are portrayed on patrol together in the frontier of the Russian land.",
                    CreationYear = 1898,
                    Medium = "Oil on canvas",
                    Dimensions = "295.3 cm × 446 cm (116.3 in × 175.6 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg/800px-Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = vasnetsov.Id,
                    GenreId = mythological.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21135"),
                    Title = "Alyonushka",
                    Description =
                        "A painting depicting a young woman, Alyonushka, a character from Russian folk tales, sitting forlornly by a pond. The painting is notable for its depiction of the Russian landscape and its melancholic mood.",
                    CreationYear = 1881,
                    Medium = "Oil on canvas",
                    Dimensions = "177 cm × 121 cm (69.7 in × 47.6 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/Vasnetsov_Alionushka.jpg/600px-Vasnetsov_Alionushka.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = vasnetsov.Id,
                    GenreId = mythological.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                    Title = "Demon Seated",
                    Description =
                        "One of Vrubel's most famous works, depicting a winged demon sitting in a pensive pose. The painting is characterized by its unusual crystalline form and vibrant colors.",
                    CreationYear = 1890,
                    Medium = "Oil on canvas",
                    Dimensions = "114 cm × 211 cm (44.9 in × 83.1 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bf/Vrubel_Demon.jpg/800px-Vrubel_Demon.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = vrubel.Id,
                    GenreId = symbolism.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21137"),
                    Title = "Demon Downcast",
                    Description =
                        "The last of Vrubel's Demon series, showing the defeated demon with broken wings. This painting is associated with the deterioration of Vrubel's mental health.",
                    CreationYear = 1902,
                    Medium = "Oil on canvas",
                    Dimensions = "139 cm × 387 cm (54.7 in × 152.4 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Vrubel_Fallen_Demon.jpg/800px-Vrubel_Fallen_Demon.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = vrubel.Id,
                    GenreId = symbolism.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                    Title = "The Ninth Wave",
                    Description =
                        "Aivazovsky's most famous painting, showing a group of people clinging to debris from a shipwreck, facing a large wave at sunrise. The title refers to the nautical belief that the ninth wave is the largest in a series of waves.",
                    CreationYear = 1850,
                    Medium = "Oil on canvas",
                    Dimensions = "221 cm × 332 cm (87.0 in × 130.7 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4a/Hovhannes_Aivazovsky_-_The_Ninth_Wave_-_Google_Art_Project.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = aivazovsky.Id,
                    GenreId = seascape.Id,
                    MuseumId = russianMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21139"),
                    Title = "Storm on the Sea at Night",
                    Description =
                        "A dramatic seascape depicting a violent storm at night, with a ship struggling against massive waves. The painting showcases Aivazovsky's mastery in depicting light and water.",
                    CreationYear = 1849,
                    Medium = "Oil on canvas",
                    Dimensions = "100 cm × 141 cm (39.4 in × 55.5 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg/800px-Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = aivazovsky.Id,
                    GenreId = seascape.Id,
                    MuseumId = russianMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                    Title = "The Rooks Have Returned",
                    Description =
                        "Savrasov's most famous work, depicting the early spring landscape with rooks nesting in birch trees. The painting conveys the sense of awakening nature and hope.",
                    CreationYear = 1871,
                    Medium = "Oil on canvas",
                    Dimensions = "62 cm × 48.5 cm (24.4 in × 19.1 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/30/Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg/600px-Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = savrasov.Id,
                    GenreId = landscape.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21141"),
                    Title = "Countryside Road",
                    Description =
                        "A serene landscape depicting a countryside road in rural Russia. The painting demonstrates Savrasov's talent for capturing the subtle poetry of simple Russian landscapes.",
                    CreationYear = 1873,
                    Medium = "Oil on canvas",
                    Dimensions = "58.8 cm × 80.5 cm (23.1 in × 31.7 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7a/Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg/800px-Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = savrasov.Id,
                    GenreId = landscape.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Italian paintings
                // Leonardo da Vinci
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21224"),
                    Title = "Mona Lisa",
                    Description =
                        "The Mona Lisa is a half-length portrait painting by Italian artist Leonardo da Vinci. Considered an archetypal masterpiece of the Italian Renaissance, it has been described as 'the best known, the most visited, the most written about, the most sung about, the most parodied work of art in the world'.",
                    CreationYear = 1503,
                    Medium = "Oil on poplar panel",
                    Dimensions = "77 cm × 53 cm (30 in × 21 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ec/Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg/687px-Mona_Lisa%2C_by_Leonardo_da_Vinci%2C_from_C2RMF_retouched.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = daVinci.Id,
                    GenreId = portrait.Id,
                    MuseumId = uffizi.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21225"),
                    Title = "The Last Supper",
                    Description =
                        "The Last Supper is a mural painting by Italian High Renaissance Leonardo da Vinci housed by the refectory of the Convent of Santa Maria delle Grazie in Milan, Italy. It depicts the scene of the Last Supper of Jesus with his apostles.",
                    CreationYear = 1498,
                    Medium = "Tempera and oil on gesso",
                    Dimensions = "460 cm × 880 cm (181 in × 346 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4b/%C3%9Altima_Cena_-_Da_Vinci_5.jpg/800px-%C3%9Altima_Cena_-_Da_Vinci_5.jpg",
                    PaintType = PaintType.Tempera,
                    ArtistId = daVinci.Id,
                    GenreId = religious.Id,
                    MuseumId = uffizi.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Michelangelo
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21226"),
                    Title = "The Creation of Adam",
                    Description =
                        "The Creation of Adam is a fresco painting by Italian artist Michelangelo, which forms part of the Sistine Chapel's ceiling, painted c. 1508–1512. It illustrates the Biblical creation narrative from the Book of Genesis in which God gives life to Adam, the first man.",
                    CreationYear = 1512,
                    Medium = "Fresco",
                    Dimensions = "280 cm × 570 cm (110 in × 224 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/64/Creaci%C3%B3n_de_Ad%C3%A1m.jpg/800px-Creaci%C3%B3n_de_Ad%C3%A1m.jpg",
                    PaintType = PaintType.Fresco,
                    ArtistId = michelangelo.Id,
                    GenreId = religious.Id,
                    MuseumId = vaticanMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21227"),
                    Title = "The Last Judgment",
                    Description =
                        "The Last Judgment is a fresco by the Italian Renaissance painter Michelangelo covering the whole altar wall of the Sistine Chapel in Vatican City. It is a depiction of the Second Coming of Christ and the final and eternal judgment by God of all humanity.",
                    CreationYear = 1541,
                    Medium = "Fresco",
                    Dimensions = "1370 cm × 1200 cm (539 in × 472 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/18/Last_Judgement_%28Michelangelo%29.jpg/600px-Last_Judgement_%28Michelangelo%29.jpg",
                    PaintType = PaintType.Fresco,
                    ArtistId = michelangelo.Id,
                    GenreId = religious.Id,
                    MuseumId = vaticanMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Botticelli
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21228"),
                    Title = "The Birth of Venus",
                    Description =
                        "The Birth of Venus is a painting by Italian artist Sandro Botticelli, probably executed in the mid 1480s. It depicts the goddess Venus arriving at the shore after her birth, when she had emerged from the sea fully-grown.",
                    CreationYear = 1485,
                    Medium = "Tempera on canvas",
                    Dimensions = "172.5 cm × 278.9 cm (67.9 in × 109.6 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg/800px-Sandro_Botticelli_-_La_nascita_di_Venere_-_Google_Art_Project_-_edited.jpg",
                    PaintType = PaintType.Tempera,
                    ArtistId = botticelli.Id,
                    GenreId = mythological.Id,
                    MuseumId = uffizi.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21229"),
                    Title = "Primavera",
                    Description =
                        "Primavera, also known as Allegory of Spring, is a large panel painting in tempera paint by the Italian Renaissance painter Sandro Botticelli made in the late 1470s or early 1480s. The painting has been described as one of the most written about, and most controversial paintings in the world.",
                    CreationYear = 1482,
                    Medium = "Tempera on wood",
                    Dimensions = "202 cm × 314 cm (80 in × 124 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Botticelli-primavera.jpg/800px-Botticelli-primavera.jpg",
                    PaintType = PaintType.Tempera,
                    ArtistId = botticelli.Id,
                    GenreId = mythological.Id,
                    MuseumId = uffizi.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Caravaggio
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21230"),
                    Title = "The Calling of Saint Matthew",
                    Description =
                        "The Calling of Saint Matthew is a masterpiece by Michelangelo Merisi da Caravaggio, depicting the moment when Jesus Christ inspires Matthew to follow him. It was completed in 1599-1600 for the Contarelli Chapel in the church of the French congregation San Luigi dei Francesi in Rome.",
                    CreationYear = 1600,
                    Medium = "Oil on canvas",
                    Dimensions = "322 cm × 340 cm (127 in × 134 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/48/The_Calling_of_Saint_Matthew-Caravaggo_%281599-1600%29.jpg/800px-The_Calling_of_Saint_Matthew-Caravaggo_%281599-1600%29.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = caravaggio.Id,
                    GenreId = religious.Id,
                    MuseumId = vaticanMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21231"),
                    Title = "Judith Beheading Holofernes",
                    Description =
                        "Judith Beheading Holofernes is a painting by the Italian early Baroque artist Caravaggio, painted in 1598-1602. The painting depicts Judith beheading Holofernes, a scene from the deuterocanonical Book of Judith in the Old Testament.",
                    CreationYear = 1602,
                    Medium = "Oil on canvas",
                    Dimensions = "144 cm × 195 cm (57 in × 77 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Caravaggio_Judith_Beheading_Holofernes.jpg/800px-Caravaggio_Judith_Beheading_Holofernes.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = caravaggio.Id,
                    GenreId = religious.Id,
                    MuseumId = vaticanMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Painting>().HasData(paintings);

            // Seed PaintingTags (Russian + Italian)
            var paintingTags = new List<PaintingTag>
            {
                // Russian painting tags (existing)
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21142"),
                    PaintingId = paintings[0].Id, // Bogatyrs
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21143"),
                    PaintingId = paintings[0].Id, // Bogatyrs
                    TagId = tags[1].Id, // 19th Century
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21144"),
                    PaintingId = paintings[0].Id, // Bogatyrs
                    TagId = tags[4].Id, // Folklore
                    CreatedDate = DateTime.UtcNow
                },

                // Italian painting tags
                // Da Vinci - Mona Lisa
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21232"),
                    PaintingId = paintings[8].Id, // Mona Lisa
                    TagId = tags[7].Id, // Italian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21233"),
                    PaintingId = paintings[8].Id, // Mona Lisa
                    TagId = tags[8].Id, // Renaissance
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21234"),
                    PaintingId = paintings[8].Id, // Mona Lisa
                    TagId = tags[9].Id, // Classical
                    CreatedDate = DateTime.UtcNow
                },

                // Botticelli - Birth of Venus
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21235"),
                    PaintingId = paintings[12].Id, // Birth of Venus
                    TagId = tags[7].Id, // Italian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21236"),
                    PaintingId = paintings[12].Id, // Birth of Venus
                    TagId = tags[8].Id, // Renaissance
                    CreatedDate = DateTime.UtcNow
                },

                // Caravaggio - The Calling of Saint Matthew
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21237"),
                    PaintingId = paintings[14].Id, // The Calling of Saint Matthew
                    TagId = tags[7].Id, // Italian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21238"),
                    PaintingId = paintings[14].Id, // The Calling of Saint Matthew
                    TagId = tags[10].Id, // Baroque
                    CreatedDate = DateTime.UtcNow
                }
            };
            
            modelBuilder.Entity<PaintingTag>().HasData(paintingTags);
        }
    }
}