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

            modelBuilder.Entity<Country>().HasData(russia);
            
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

            modelBuilder.Entity<City>().HasData(moscow, stPetersburg);
            
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

            modelBuilder.Entity<Museum>().HasData(tretyakovGallery, russianMuseum);
            
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

            modelBuilder.Entity<Genre>().HasData(mythological, landscape, seascape, symbolism);

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
                }
            };

            modelBuilder.Entity<Tag>().HasData(tags);

            // Seed Artists
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

            modelBuilder.Entity<Artist>().HasData(vasnetsov, vrubel, aivazovsky, savrasov);

            // Seed Biographies
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
                }
            };

            modelBuilder.Entity<Biography>().HasData(biographies);

            // Seed Artist Images
            var artistImages = new List<ArtistImage>
            {
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21130"),
                    PictureUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/2/29/Viktor_Vasnetsov_-_Self-portrait_-_Google_Art_Project.jpg",
                    IsMain = true,
                    PublicId = "artist_vasnetsov",
                    ArtistId = vasnetsov.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21131"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7f/Vrubel_Self-Portrait_1882.jpg",
                    IsMain = true,
                    PublicId = "artist_vrubel",
                    ArtistId = vrubel.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21132"),
                    PictureUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/b/b5/Aivazovsky_-_Self-portrait_1874.jpg",
                    IsMain = true,
                    PublicId = "artist_aivazovsky",
                    ArtistId = aivazovsky.Id,
                    CreatedDate = DateTime.UtcNow
                },
                new ArtistImage
                {
                    Id = Guid.Parse("0c6aeae0-5c40-4085-8993-7d7b5db21133"),
                    PictureUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9f/Alexey_Savrasov.jpg",
                    IsMain = true,
                    PublicId = "artist_savrasov",
                    ArtistId = savrasov.Id,
                    CreatedDate = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<ArtistImage>().HasData(artistImages);

            // Seed Paintings
            var paintings = new List<Painting>
            {
                // Vasnetsov's paintings
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21134"),
                    Title = "Bogatyrs",
                    Description =
                        "Also known as Three Bogatyrs, this painting depicts three of the most legendary bogatyrs (medieval Russian knights): Dobrynya Nikitich, Ilya Muromets and Alyosha Popovich. They are portrayed on patrol together in the frontier of the Russian land.",
                    CreationYear = 1898,
                    Medium = "Oil on canvas",
                    Dimensions = "295.3 cm × 446 cm (116.3 in × 175.6 in)",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/4/4e/Viktor_Vasnetsov_-_Bogatyrs_-_Google_Art_Project.jpg",
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
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/97/Vasnetsov_Alionushka.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = vasnetsov.Id,
                    GenreId = mythological.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Vrubel's paintings
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21136"),
                    Title = "Demon Seated",
                    Description =
                        "One of Vrubel's most famous works, depicting a winged demon sitting in a pensive pose. The painting is characterized by its unusual crystalline form and vibrant colors.",
                    CreationYear = 1890,
                    Medium = "Oil on canvas",
                    Dimensions = "114 cm × 211 cm (44.9 in × 83.1 in)",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/b/bf/Vrubel_Demon.jpg",
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
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/fc/Vrubel_Fallen_Demon.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = vrubel.Id,
                    GenreId = symbolism.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Aivazovsky's paintings
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21138"),
                    Title = "The Ninth Wave",
                    Description =
                        "Aivazovsky's most famous painting, showing a group of people clinging to debris from a shipwreck, facing a large wave at sunrise. The title refers to the nautical belief that the ninth wave is the largest in a series of waves.",
                    CreationYear = 1850,
                    Medium = "Oil on canvas",
                    Dimensions = "221 cm × 332 cm (87.0 in × 130.7 in)",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/4/4a/Hovhannes_Aivazovsky_-_The_Ninth_Wave_-_Google_Art_Project.jpg",
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
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/5/51/Aivazovsky%2C_Ivan_-_Storm_on_the_Sea_at_Night.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = aivazovsky.Id,
                    GenreId = seascape.Id,
                    MuseumId = russianMuseum.Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Savrasov's paintings
                new Painting
                {
                    Id = Guid.Parse("1c6aeae0-5c40-4085-8993-7d7b5db21140"),
                    Title = "The Rooks Have Returned",
                    Description =
                        "Savrasov's most famous work, depicting the early spring landscape with rooks nesting in birch trees. The painting conveys the sense of awakening nature and hope.",
                    CreationYear = 1871,
                    Medium = "Oil on canvas",
                    Dimensions = "62 cm × 48.5 cm (24.4 in × 19.1 in)",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/3/30/Alexei_Savrasov_-_The_Rooks_Have_Returned.jpg",
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
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/commons/7/7a/Alexei_Savrasov_-_Country_Road_-_Google_Art_Project.jpg",
                    PaintType = PaintType.Oil,
                    ArtistId = savrasov.Id,
                    GenreId = landscape.Id,
                    MuseumId = tretyakovGallery.Id,
                    CreatedDate = DateTime.UtcNow
                }
            };

            modelBuilder.Entity<Painting>().HasData(paintings);

            // Seed PaintingTags
            var paintingTags = new List<PaintingTag>
            {
                // Vasnetsov - Bogatyrs tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21142"),
                    PaintingId = paintings[0].Id,
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21143"),
                    PaintingId = paintings[0].Id,
                    TagId = tags[1].Id, // 19th Century
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21144"),
                    PaintingId = paintings[0].Id,
                    TagId = tags[4].Id, // Folklore
                    CreatedDate = DateTime.UtcNow
                },

                // Vasnetsov - Alyonushka tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21145"),
                    PaintingId = paintings[1].Id,
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21146"),
                    PaintingId = paintings[1].Id,
                    TagId = tags[1].Id, // 19th Century
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21147"),
                    PaintingId = paintings[1].Id,
                    TagId = tags[4].Id, // Folklore
                    CreatedDate = DateTime.UtcNow
                },

                // Vrubel - Demon Seated tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21148"),
                    PaintingId = paintings[2].Id,
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21149"),
                    PaintingId = paintings[2].Id,
                    TagId = tags[1].Id, // 19th Century
                    CreatedDate = DateTime.UtcNow
                },

                // Vrubel - Demon Downcast tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21150"),
                    PaintingId = paintings[3].Id,
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21151"),
                    PaintingId = paintings[3].Id,
                    TagId = tags[2].Id, // Early 20th Century
                    CreatedDate = DateTime.UtcNow
                },

                // Aivazovsky - The Ninth Wave tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21152"),
                    PaintingId = paintings[4].Id,
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21153"),
                    PaintingId = paintings[4].Id,
                    TagId = tags[1].Id, // 19th Century
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21154"),
                    PaintingId = paintings[4].Id,
                    TagId = tags[3].Id, // Romanticism
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21155"),
                    PaintingId = paintings[4].Id,
                    TagId = tags[5].Id, // Sea
                    CreatedDate = DateTime.UtcNow
                },

                // Aivazovsky - Storm on the Sea at Night tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21156"),
                    PaintingId = paintings[5].Id,
                    TagId = tags[0].Id, // Russian Art
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21157"),
                    PaintingId = paintings[5].Id,
                    TagId = tags[1].Id, // 19th Century
                    CreatedDate = DateTime.UtcNow
                },
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21158"),
                    PaintingId = paintings[5].Id,
                    TagId = tags[5].Id, // Sea
                    CreatedDate = DateTime.UtcNow
                },

                // Savrasov - The Rooks Have Returned tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21159"),
                    PaintingId = paintings[6].Id,
                    TagId = tags[0].Id,
                    CreatedDate = DateTime.UtcNow
                },

                // Savrasov - Countryside Road tags
                new PaintingTag
                {
                    Id = Guid.Parse("2c6aeae0-5c40-4085-8993-7d7b5db21160"),
                    PaintingId = paintings[7].Id,
                    TagId = tags[0].Id,
                    CreatedDate = DateTime.UtcNow
                }
            };
            
            modelBuilder.Entity<PaintingTag>().HasData(paintingTags);
        }
    }
}