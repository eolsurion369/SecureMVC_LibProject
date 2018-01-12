using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibProject_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LipProject_Api.Models
{
    public class DbInitializer
    {
        public static void Initialize(LibProjectContext context)
        {
            if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();

            if (context.AdultMember.Any())
            {
                return; // Db has already been seeded
            }

            var adults = new AdultMember[]
            {
                new AdultMember { FirstName = "Yogi", LastName = "Bear", MidInit = "B", Suffix = null, Birthdate = DateTime.Parse("2000-12-25 12:00"), InActive = null, InActiveDate = null },
                new AdultMember { FirstName = "Peter", LastName = "Parker", MidInit = "P", Suffix = null, Birthdate = DateTime.Parse("2000-12-25 12:00"), InActive = null, InActiveDate = null },
                new AdultMember { FirstName = "Bruce", LastName = "Wayne", MidInit = "S", Suffix = null, Birthdate = DateTime.Parse("2000-12-25 12:00"), InActive = null, InActiveDate = null },
                new AdultMember { FirstName = "Mother", LastName = "Hubbard", MidInit = "H", Suffix = null, Birthdate = DateTime.Parse("2000-12-25 12:00"), InActive = null, InActiveDate = null }
            };

            foreach (AdultMember adult in adults) { context.AdultMember.Add(adult); };
            context.SaveChanges();

            var juveniles = new JuvenileMember[]
            {
                new JuvenileMember {AdultId=1, FirstName = "BooBoo", LastName = "Bear", MidInit = "B", Suffix = null, Birthdate = DateTime.Parse("2017-12-25 12:00"), InActive = null, InActiveDate = null },
                new JuvenileMember {AdultId=4, FirstName = "Poor", LastName = "Dog", MidInit = "D", Suffix = null, Birthdate = DateTime.Parse("2017-12-25 12:00"), InActive = null, InActiveDate = null }
            };

            foreach (JuvenileMember juvenile in juveniles) { context.JuvenileMember.Add(juvenile); };
            context.SaveChanges();

            var mType = new MediaType[]
            {
                new MediaType { Id = "b", Type = "Book", InActive = null, InActiveDate = null},
                new MediaType { Id = "m", Type = "Music", InActive = null, InActiveDate = null},
                new MediaType { Id = "v", Type = "Movie", InActive = null, InActiveDate = null},
                new MediaType { Id = "z", Type = "Magazine", InActive = null, InActiveDate = null},
                new MediaType { Id = "g", Type = "Game", InActive = null, InActiveDate = null}
            };

            foreach (MediaType type in mType) { context.MediaType.Add(type); };
            context.SaveChanges();

            var mFormat = new MediaFormat[]
            {
                new MediaFormat { Id = "h", Format = "Hard Cover"},
                new MediaFormat { Id = "s", Format = "Paper Back"},
                new MediaFormat { Id = "k", Format = "Kindle"},
                new MediaFormat { Id = "a", Format = "Audio Cassette"},
                new MediaFormat { Id = "c", Format = "CD"},
                new MediaFormat { Id = "d", Format = "DVD"},
                new MediaFormat { Id = "g", Format = "Digital Download"},
                new MediaFormat { Id = "v", Format = "VHS"},
                new MediaFormat { Id = "l", Format = "Leaflet"}
            };

            foreach (MediaFormat format in mFormat) { context.MediaFormat.Add(format); };
            context.SaveChanges();

            var mFormatType = new MediaTypeFormat[]
            {
                new MediaTypeFormat { MediaTypeId = "b", MediaFormatId = "h" },
                new MediaTypeFormat { MediaTypeId = "b", MediaFormatId = "s"  },
                new MediaTypeFormat { MediaTypeId = "b", MediaFormatId = "k" },
                new MediaTypeFormat { MediaTypeId = "b", MediaFormatId = "a" },
                new MediaTypeFormat { MediaTypeId = "m", MediaFormatId = "c" },
                new MediaTypeFormat { MediaTypeId = "m", MediaFormatId = "d" },
                new MediaTypeFormat { MediaTypeId = "m", MediaFormatId = "a" },
                new MediaTypeFormat { MediaTypeId = "m", MediaFormatId = "g" },
                new MediaTypeFormat { MediaTypeId = "v", MediaFormatId = "d" },
                new MediaTypeFormat { MediaTypeId = "v", MediaFormatId = "v" },
                new MediaTypeFormat { MediaTypeId = "v", MediaFormatId = "g" },
                new MediaTypeFormat { MediaTypeId = "z", MediaFormatId = "s" },
                new MediaTypeFormat { MediaTypeId = "z", MediaFormatId = "g" },
                new MediaTypeFormat { MediaTypeId = "g", MediaFormatId = "d" },
                new MediaTypeFormat { MediaTypeId = "g", MediaFormatId = "g" }
            };

            foreach (MediaTypeFormat formatType in mFormatType) { context.MediaTypeFormat.Add(formatType); };
            context.SaveChanges();

            var mGenre = new Genre[]
            {
                new Genre {Id = "sf", Name = "Science Fiction"},
                new Genre {Id = "fy", Name = "Fantasy"},
                new Genre {Id = "ab", Name = "Autobiography"},
                new Genre {Id = "hf", Name = "Hitorical Fiction"},
                new Genre {Id = "hr", Name = "Hard Rock"},
                new Genre {Id = "hm", Name = "Heavy Metal"},
                new Genre {Id = "gr", Name = "Grunge"},
                new Genre {Id = "ac", Name = "Action"},
                new Genre {Id = "th", Name = "Thriller"},
                new Genre {Id = "ho", Name = "Horror"},
                new Genre {Id = "rc", Name = "Romantic Comedy"},
                new Genre {Id = "cy", Name = "Comedy"},
                new Genre {Id = "an", Name = "Animated"},
                new Genre {Id = "da", Name = "3d Animation"},
                new Genre {Id = "sp", Name = "Sports"},
                new Genre {Id = "wo", Name = "Womens"},
                new Genre {Id = "co", Name = "Cooking"},
                new Genre {Id = "ca", Name = "Cars"},
                new Genre {Id = "nw", Name = "News"},
                new Genre {Id = "mm", Name = "MMORPG"},
                new Genre {Id = "in", Name = "Indy"},
                new Genre {Id = "fp", Name = "First Person Shooter"},
                new Genre {Id = "cr", Name = "Crafting"}
            };

            foreach (Genre genre in mGenre) { context.Genre.Add(genre); };
            context.SaveChanges();

            var tGenre = new MediaTypeGenre[]
            {
                new MediaTypeGenre {MediaTypeId = "b", GenreId = "sf"},
                new MediaTypeGenre {MediaTypeId = "b", GenreId = "fy"},
                new MediaTypeGenre {MediaTypeId = "b", GenreId = "ab"},
                new MediaTypeGenre {MediaTypeId = "b", GenreId = "hf"},
                new MediaTypeGenre {MediaTypeId = "m", GenreId = "hr"},
                new MediaTypeGenre {MediaTypeId = "m", GenreId = "hm"},
                new MediaTypeGenre {MediaTypeId = "m", GenreId = "gr"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "ac"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "th"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "hr"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "rc"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "cy"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "an"},
                new MediaTypeGenre {MediaTypeId = "v", GenreId = "da"},
                new MediaTypeGenre {MediaTypeId = "z", GenreId = "sp"},
                new MediaTypeGenre {MediaTypeId = "z", GenreId = "wo"},
                new MediaTypeGenre {MediaTypeId = "z", GenreId = "co"},
                new MediaTypeGenre {MediaTypeId = "z", GenreId = "ca"},
                new MediaTypeGenre {MediaTypeId = "z", GenreId = "nw"},
                new MediaTypeGenre {MediaTypeId = "g", GenreId = "mm"},
                new MediaTypeGenre {MediaTypeId = "g", GenreId = "in"},
                new MediaTypeGenre {MediaTypeId = "g", GenreId = "fp"},
                new MediaTypeGenre {MediaTypeId = "g", GenreId = "cr"}
            };

            foreach (MediaTypeGenre mTGenre in tGenre) { context.MediaTypeGenre.Add(mTGenre); };
            context.SaveChanges();

            var sSeries = new Series[]
            {
                new Series {Name = "The Wheel of Time", InActive = null, InActiveDate = null},
                new Series {Name = "The Sword of Truth", InActive = null, InActiveDate = null},
                new Series {Name = "Jeepers Creepers", InActive = null, InActiveDate = null},
                new Series {Name = "Star Wars", InActive = null, InActiveDate = null},
                new Series {Name = "Warcraft", InActive = null, InActiveDate = null}
            };

            foreach (Series series in sSeries) { context.Series.Add(series); };
            context.SaveChanges();

            var Publishers = new Publisher[]
            {
                new Publisher {Name = "Tor Books", InActive = null, InActiveDate = null},
                new Publisher {Name = "United Artists", InActive = null, InActiveDate = null },
                new Publisher {Name = "Lucasfilm LTD", InActive = null, InActiveDate = null},
                new Publisher {Name = "Capital Records", InActive = null, InActiveDate = null},
                new Publisher {Name = "Giant Records", InActive = null, InActiveDate = null},
                new Publisher {Name = "Megaforce Records", InActive = null, InActiveDate = null},
                new Publisher {Name = "Elektra Records", InActive = null, InActiveDate = null},
                new Publisher {Name = "Brendan Ripp", InActive = null, InActiveDate = null},
                new Publisher {Name = "Blizzard Entertainment", InActive = null, InActiveDate = null}
            };

            foreach (Publisher publisher in Publishers) { context.Publisher.Add(publisher); };
            context.SaveChanges();

            var mMedia = new Media[]
            {
                new Media {Title ="The Eye of the World", SeriesId = 1, Author = "Jordan, Robert", PublisherId = 1, CopyRightDate = DateTime.Parse("1990-01-15 12:00"),  Characteristics = "782pg (PB) / 702pg (HB) : Audio Length 29h 32m : illustrations, maps",
                    Summary = "In the Third Age, an age of prophecy when the world and time themselves hang in the balance, the Dark One, imprisoned by the Creator, is stirring in Shayol Ghul.", InActive = null, InActiveDate = null},
                new Media {Title ="The Great Hunt", SeriesId = 1, Author = "Jordan, Robert", PublisherId = 1, CopyRightDate = DateTime.Parse("1990-11-15 12:00"),  Characteristics = "681pp (PB) / 599pp (HB) : Audio Lenght 26h 08m : illustrations, maps",
                    Summary = "The Wheel of Time turns and Ages come and pass. What was, what will be, and what is, may yet fall under the Shadow. For centuries, gleemen have told of The Great Hunt of the Horn. Now the Horn itself is found: the Horn of Valere long thought only legend, the Horn which will raise the dead heroes of the ages. And it is stolen.",
                    InActive = null, InActiveDate = null},
                new Media {Title ="Wizards First Rule", SeriesId = 2, Author = "Goodkind, Terry", PublisherId = 1, CopyRightDate = DateTime.Parse("1994-08-15 12:00"),  Characteristics = "573 pages : map ",
                    Summary = "In the aftermath of the brutal murder of his father, a mysterious woman, Kahlan Amnell, appears in Richard Cypher's forest sanctuary seeking help . . . and more. His world, his very beliefs, are shattered when ancient debts come due with thundering violence. In a dark age it takes courage to live, and more than mere courage to challenge those who hold dominion, Richard and Kahlan must take up that challenge or become the next victims. Beyond awaits a bewitching land where even the best of their hearts could betray them. Yet, Richard fears nothing so much as what secrets his sword might reveal about his own soul. Falling in love would destroy them--for reasons Richard can't imagine and Kahlan dare not say. In their darkest hour, hunted relentlessly, tormented by treachery and loss, Kahlan calls upon Richard to reach beyond his sword--to invoke within himself something more noble. Neither knows that the rules of battle have just changed ... or that their time has run out.",
                    InActive = null, InActiveDate = null},
                new Media {Title ="The Sickness", SeriesId = null, Author = "Disturbed", PublisherId = 5, CopyRightDate = DateTime.Parse("2000-03-07 12:00"),  Characteristics = "12 songs : Audio Length 47m 34s",
                    Summary = "The Sickness is the debut studio album by American metal band Disturbed. The album was released on March 7, 2000. The album peaked at number 29 on the Billboard 200 chart and it has spent a total of 103 weeks on that chart, as of June 2011. It is, to date, Disturbed's only album to not hit number one on the Billboard 200.[4] As of 2011, The Sickness has been certified 4x platinum by the RIAA, with sales in the United States at around 4,248,000 copies, making it the band's most successful album", InActive = null, InActiveDate = null},
                new Media {Title ="Ride the Lightning", SeriesId = null, Author = "Metallica", PublisherId = 6, CopyRightDate = DateTime.Parse("1984-07-27 12:00"),  Characteristics = "8 songs : Audio Length 47m 28s",
                    Summary = "Ride the Lightning is the second studio album by American heavy metal band Metallica, released on July 27, 1984, by the independent record label Megaforce Records. The album was recorded in three weeks with producer Flemming Rasmussen at the Sweet Silence Studios in Copenhagen, Denmark. The artwork, based on a concept by the band, depicts an electric chair being struck by lightning flowing from the band logo. The title was taken from a passage in Stephen King's novel The Stand. Although rooted in the thrash metal genre, the album showcased the band's musical growth and lyrical sophistication. This was partly because bassist Cliff Burton introduced the basics of music theory to the rest of the band and had more input in the songwriting. Instead of relying strictly on fast tempos as on its debut Kill 'Em All, Metallica broadened its approach by employing acoustic guitars, extended instrumentals, and more complex harmonies. The overall recording costs were paid by Metallica's European label Music for Nations because Megaforce was unable to cover it. It was the last album to feature songwriting contributions from former lead guitarist Dave Mustaine, and the first to feature contributions from his replacement, Kirk Hammett.",
                    InActive = null, InActiveDate = null},
                new Media {Title ="Countdown to Extinction", SeriesId = null, Author = "Megadeth", PublisherId = 4, CopyRightDate = DateTime.Parse("1992-07-14 12:00"),  Characteristics = "11 songs : Audio Length 47m 26s",
                    Summary = "Countdown to Extinction is Megadeth's fifth studio album, and the second to feature the line-up of Dave Mustaine, Marty Friedman, David Ellefson and Nick Menza. In an interview for Billboard at the time, Mustaine admitted that he fired past members Chuck Behler and Jeff Young because they resisted his pleas to seek rehabilitative counseling. He added that it was a 'major accomplishment' that all four members of Megadeth contributed material to the album, unlike their earlier releases which were 'nearly all Mustaine'. Mustaine also revealed that producer Max Norman had significant input to the album by making 'a lot of suggestions and a lot of great artistic ideas'. Guitarist Marty Friedman said that unlike Rust in Peace, the creation of this record was 'completely different'. He further stated that the band had changed the songs 'a million times' before recording them on demo and entering the studio.",
                    InActive = null, InActiveDate = null},
                new Media {Title ="Master of Puppets", SeriesId = null, Author = "Metallica", PublisherId = 7, CopyRightDate = DateTime.Parse("1986-03-03 12:00"),  Characteristics = "8 songs : Audio Length 54m 47s",
                    Summary = "Master of Puppets is the third studio album by American heavy metal band Metallica. It was released on March 3, 1986 by Elektra Records. Recorded at the Sweet Silence Studios with producer Flemming Rasmussen, it was the first Metallica album released on a major record label. Master of Puppets was the band's last album to feature bassist Cliff Burton, who died in a bus accident in Sweden during the album's promotional tour. The album peaked at number 29 on the Billboard 200 and became the first thrash metal album to be certified platinum. It was certified 6× platinum by the Recording Industry Association of America (RIAA) in 2003 for shipping six million copies in the United States. The album was eventually certified 6× platinum by Music Canada and gold by the British Phonographic Industry (BPI).",
                    InActive = null, InActiveDate = null},
                new Media {Title ="Jeepers Creepers", SeriesId = null, Author = "Victor Salva", PublisherId = 2, CopyRightDate = DateTime.Parse("2001-08-31 12:00"),  Characteristics = "Running Time 91m",
                    Summary = "Jeepers Creepers is a 2001 American-German horror film written and directed by Victor Salva. The film takes its name from the 1938 song 'Jeepers Creepers', which is featured in the film. Francis Ford Coppola executive produced, and the film stars Gina Philips, Justin Long, Jonathan Breck, and Eileen Brennan. Philips and Long play two older siblings who become the targets of a demonic creature (Breck) in rural Florida.",
                    InActive = null, InActiveDate = null},
                new Media {Title ="Star Wars - A New Hope", SeriesId = null, Author = "George Lucas", PublisherId = 3, CopyRightDate = DateTime.Parse("1977-05-25 12:00"),  Characteristics = "Running Time 121m",
                    Summary = "Star Wars (later retitled Star Wars: Episode IV – A New Hope) is a 1977 American epic space opera film written and directed by George Lucas. It is the first film in the original Star Wars trilogy and the beginning of the Star Wars franchise. Starring Mark Hamill, Harrison Ford, Carrie Fisher, Peter Cushing, Alec Guinness, David Prowse, James Earl Jones, Anthony Daniels, Kenny Baker, and Peter Mayhew, the film's plot focuses on the Rebel Alliance, led by Princess Leia (Fisher), and its attempt to destroy the Galactic Empire's space station, the Death Star. This conflict disrupts the isolated life of farmhand Luke Skywalker (Hamill), who inadvertently acquires two droids that possess stolen architectural plans for the Death Star. When the Empire begins a destructive search for the missing droids, Skywalker accompanies Jedi Master Obi-Wan Kenobi (Guinness) on a mission to return the plans to the Rebel Alliance and rescue Leia from her imprisonment by the Empire.",
                    InActive = null, InActiveDate = null},
                 new Media {Title ="Sports Illustrated", SeriesId = null, Author = "Chris Stone", PublisherId = 8, CopyRightDate = DateTime.Parse("1954-08-16 12:00"),  Characteristics = "Bi-Weekly publication",
                    Summary = "Sports Illustrated is an American sports media franchise owned by Time Inc. Its self-titled magazine has over 3 million subscribers and is read by 23 million people each week, including over 18 million men.[3] It was the first magazine with circulation over one million to win the National Magazine Award for General Excellence twice. Its swimsuit issue, which has been published since 1964, is now an annual publishing event that generates its own television shows, videos and calendars.",
                    InActive = null, InActiveDate = null},
                 new Media {Title ="World of Warcraft", SeriesId = null, Author = "Padro, Rob; Kaplan, Jeff; Chilton, Tom", PublisherId = 9, CopyRightDate = DateTime.Parse("2004-11-23 12:00"),  Characteristics = " ",
                    Summary = "World of Warcraft (WoW) is a massively multiplayer online role-playing game (MMORPG) released in 2004 by Blizzard Entertainment. It is the fourth released game set in the Warcraft fantasy universe. World of Warcraft takes place within the Warcraft world of Azeroth, approximately four years after the events at the conclusion of Blizzard's previous Warcraft release, Warcraft III: The Frozen Throne. Blizzard Entertainment announced World of Warcraft on September 2, 2001. The game was released on November 23, 2004, on the 10th anniversary of the Warcraft franchise.",
                    InActive = null, InActiveDate = null},
            };

            foreach (Media media in mMedia) { context.Media.Add(media); };
            context.SaveChanges();

            var mCopies = new MediaCopy[]
            {
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 3, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "s", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "s", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "k", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 2, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 2, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 2, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 3, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 2, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "s", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 2, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "s", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 2, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "k", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 1, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "h", CopyNumber = 3, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "s", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "s", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "k", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 3, MediaTypeId = "b", MediaGenreId = "fy", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 4, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 4, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 4, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 4, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 5, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 5, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 5, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 5, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 6, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 6, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 6, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 6, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 7, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 7, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "c", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 7, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 7, MediaTypeId = "m", MediaGenreId = "hm", MediaFormatId = "a", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 8, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "d", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 8, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "d", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 8, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 8, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "v", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 9, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "d", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 9, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "d", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 9, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 9, MediaTypeId = "v", MediaGenreId = "ho", MediaFormatId = "v", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 10, MediaTypeId = "z", MediaGenreId = "sp", MediaFormatId = "l", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 10, MediaTypeId = "z", MediaGenreId = "sp", MediaFormatId = "l", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 10, MediaTypeId = "z", MediaGenreId = "sp", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 10, MediaTypeId = "z", MediaGenreId = "sp", MediaFormatId = "g", CopyNumber = 2, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 11, MediaTypeId = "g", MediaGenreId = "mm", MediaFormatId = "g", CopyNumber = 1, InActive = null, InActiveDate = null},
                new MediaCopy { MediaId = 11, MediaTypeId = "g", MediaGenreId = "mm", MediaFormatId = "g", CopyNumber = 2, InActive = null, InActiveDate = null},
            };

            foreach (MediaCopy mCopy in mCopies) { context.MediaCopy.Add(mCopy); };
            context.SaveChanges();

            var mContent = new MediaContent[]
            {
                new MediaContent { MediaId = 1, ContentItemOrder = 1, ContentItem = "Prologue"},
                new MediaContent { MediaId = 1, ContentItemOrder = 2, ContentItem = "Maps"},
                new MediaContent { MediaId = 1, ContentItemOrder = 3, ContentItem = "An Empty Road"},
                new MediaContent { MediaId = 1, ContentItemOrder = 4, ContentItem = "Strangers"},
                new MediaContent { MediaId = 1, ContentItemOrder = 5, ContentItem = "The Peddler"},
                new MediaContent { MediaId = 1, ContentItemOrder = 6, ContentItem = "The Gleeman"},
                new MediaContent { MediaId = 1, ContentItemOrder = 7, ContentItem = "Winternight"},
                new MediaContent { MediaId = 1, ContentItemOrder = 8, ContentItem = "The Westwood"},
                new MediaContent { MediaId = 2, ContentItemOrder = 1, ContentItem = "Map"},
                new MediaContent { MediaId = 2, ContentItemOrder = 2, ContentItem = "Prologue"},
                new MediaContent { MediaId = 2, ContentItemOrder = 3, ContentItem = "The Flame of Tar Valon"},
                new MediaContent { MediaId = 2, ContentItemOrder = 4, ContentItem = "The Welcome"},
                new MediaContent { MediaId = 2, ContentItemOrder = 5, ContentItem = "Friends and Enemies"},
                new MediaContent { MediaId = 2, ContentItemOrder = 6, ContentItem = "Summoned"},
                new MediaContent { MediaId = 2, ContentItemOrder = 7, ContentItem = "The Shadow in Shienar"},
                new MediaContent { MediaId = 2, ContentItemOrder = 8, ContentItem = "Dark Prophecy"},
                new MediaContent { MediaId = 3, ContentItemOrder = 1, ContentItem = "Chapter 1"},
                new MediaContent { MediaId = 3, ContentItemOrder = 2, ContentItem = "Chapter 2"},
                new MediaContent { MediaId = 3, ContentItemOrder = 3, ContentItem = "Chapter 3"},
                new MediaContent { MediaId = 3, ContentItemOrder = 4, ContentItem = "Chapter 4"},
                new MediaContent { MediaId = 3, ContentItemOrder = 5, ContentItem = "Chapter 5"},
                new MediaContent { MediaId = 3, ContentItemOrder = 6, ContentItem = "Chapter 6"},
                new MediaContent { MediaId = 3, ContentItemOrder = 7, ContentItem = "Chapter 7"},
                new MediaContent { MediaId = 3, ContentItemOrder = 8, ContentItem = "Chapter 8"},
                new MediaContent { MediaId = 4, ContentItemOrder = 1, ContentItem = "Voices"},
                new MediaContent { MediaId = 4, ContentItemOrder = 2, ContentItem = "The Game"},
                new MediaContent { MediaId = 4, ContentItemOrder = 3, ContentItem = "Stupify"},
                new MediaContent { MediaId = 4, ContentItemOrder = 4, ContentItem = "Down with the Sickness"},
                new MediaContent { MediaId = 4, ContentItemOrder = 5, ContentItem = "Violence Fetish"},
                new MediaContent { MediaId = 4, ContentItemOrder = 6, ContentItem = "Fear"},
                new MediaContent { MediaId = 4, ContentItemOrder = 7, ContentItem = "Numb"},
                new MediaContent { MediaId = 4, ContentItemOrder = 8, ContentItem = "Want"},
                new MediaContent { MediaId = 4, ContentItemOrder = 9, ContentItem = "Conflict"},
                new MediaContent { MediaId = 4, ContentItemOrder = 10, ContentItem = "Shout 2000"},
                new MediaContent { MediaId = 4, ContentItemOrder = 11, ContentItem = "Droppin' Plates"},
                new MediaContent { MediaId = 4, ContentItemOrder = 12, ContentItem = "Meaning of Life"},
                new MediaContent { MediaId = 5, ContentItemOrder = 1, ContentItem = "Fight Fire with Fire"},
                new MediaContent { MediaId = 5, ContentItemOrder = 2, ContentItem = "Ride the Lightning"},
                new MediaContent { MediaId = 5, ContentItemOrder = 3, ContentItem = "For WHom the Bell Tolls"},
                new MediaContent { MediaId = 5, ContentItemOrder = 4, ContentItem = "Fade to Black"},
                new MediaContent { MediaId = 5, ContentItemOrder = 5, ContentItem = "Trapped Under Ice"},
                new MediaContent { MediaId = 5, ContentItemOrder = 6, ContentItem = "Escape"},
                new MediaContent { MediaId = 5, ContentItemOrder = 7, ContentItem = "Creeping Death"},
                new MediaContent { MediaId = 5, ContentItemOrder = 8, ContentItem = "The Call of Ktulu"},
                new MediaContent { MediaId = 6, ContentItemOrder = 1, ContentItem = "Skin O' My Teeth"},
                new MediaContent { MediaId = 6, ContentItemOrder = 2, ContentItem = "Symphony of Destruction"},
                new MediaContent { MediaId = 6, ContentItemOrder = 3, ContentItem = "Achitecture of Aggression"},
                new MediaContent { MediaId = 6, ContentItemOrder = 4, ContentItem = "Foreclosure of Dawn"},
                new MediaContent { MediaId = 6, ContentItemOrder = 5, ContentItem = "Sweating Bullets"},
                new MediaContent { MediaId = 6, ContentItemOrder = 6, ContentItem = "This was My Life"},
                new MediaContent { MediaId = 6, ContentItemOrder = 7, ContentItem = "Countdown to Extinction"},
                new MediaContent { MediaId = 6, ContentItemOrder = 8, ContentItem = "Hig Speed Dirt"},
                new MediaContent { MediaId = 6, ContentItemOrder = 9, ContentItem = "Psychotron"},
                new MediaContent { MediaId = 6, ContentItemOrder = 10, ContentItem = "Captive Honour"},
                new MediaContent { MediaId = 6, ContentItemOrder = 11, ContentItem = "Ashes in Your Mouth"},
                new MediaContent { MediaId = 7, ContentItemOrder = 1, ContentItem = "Master of Puppets"},
                new MediaContent { MediaId = 7, ContentItemOrder = 2, ContentItem = "Battery"},
                new MediaContent { MediaId = 7, ContentItemOrder = 3, ContentItem = "The Thing that Should Not Be"},
                new MediaContent { MediaId = 7, ContentItemOrder = 4, ContentItem = "Welcome Home Sanitarium"},
                new MediaContent { MediaId = 7, ContentItemOrder = 5, ContentItem = "Disposable Heroes"},
                new MediaContent { MediaId = 7, ContentItemOrder = 6, ContentItem = "Leper Messiah"},
                new MediaContent { MediaId = 7, ContentItemOrder = 7, ContentItem = "Orion"},
                new MediaContent { MediaId = 7, ContentItemOrder = 8, ContentItem = "Damage, Inc."},
            };

            foreach (MediaContent mCont in mContent) { context.MediaContent.Add(mCont); };
            context.SaveChanges();

            var cOuts = new CheckOut[]
            {
                new CheckOut { AdultId = 1, JuvenileId = null, MediaCopyId = 1, DueDate = DateTime.Parse("2018-01-13"), CheckedInDate = null },
                new CheckOut { AdultId = 1, JuvenileId = 1, MediaCopyId = 23, DueDate = DateTime.Parse("2018-01-13"), CheckedInDate = null },
                new CheckOut { AdultId = 2, JuvenileId = null, MediaCopyId = 39, DueDate = DateTime.Parse("2018-01-13"), CheckedInDate = null },
            };

            foreach (CheckOut cOut in cOuts) { context.CheckOut.Add(cOut); };
            context.SaveChanges();

            var aTypes = new AddrType[]
            {
                new AddrType {Id = "b", Type = "Business", InActive = null, InActiveDate = null},
                new AddrType {Id = "h", Type = "Home", InActive = null, InActiveDate = null},
                new AddrType {Id = "s", Type = "Shipping", InActive = null, InActiveDate = null}
            };

            foreach (AddrType type in aTypes) { context.AddrType.Add(type); };
            context.SaveChanges();

            var addresses = new Address[]
            {
                new Address { AddrTypeId = "h", AddrLn1 = "123 Main Street", AddrLn2 = null, City = "Seattle", State = "WA", Zip = "98117", InActive = null, InActiveDate = null},
                new Address { AddrTypeId = "h", AddrLn1 = "456 Second Ave", AddrLn2 = null, City = "Seattle", State = "WA", Zip = "98117", InActive = null, InActiveDate = null},
                new Address { AddrTypeId = "b", AddrLn1 = "999 Pike Street", AddrLn2 = null, City = "Seattle", State = "WA", Zip = "98117", InActive = null, InActiveDate = null},
                new Address { AddrTypeId = "s", AddrLn1 = "666 Devils Road", AddrLn2 = null, City = "Seattle", State = "WA", Zip = "98117", InActive = null, InActiveDate = null}
            };

            foreach (Address addr in addresses) { context.Address.Add(addr); };
            context.SaveChanges();

            var memberAddresses = new AdultMemberAddress[]
            {
                new AdultMemberAddress { AdultId = 1, AddressId = 1, InActive = null, InActiveDate = null},
                new AdultMemberAddress { AdultId = 1, AddressId = 3, InActive = null, InActiveDate = null},
                new AdultMemberAddress { AdultId = 4, AddressId = 2, InActive = null, InActiveDate = null},
                new AdultMemberAddress { AdultId = 3, AddressId = 4, InActive = null, InActiveDate = null}
            };

            foreach (AdultMemberAddress mAddr in memberAddresses) { context.AdultMemberAddress.Add(mAddr); };
            context.SaveChanges();

            var emailAddresses = new Email[]
            {
                new Email {Addr = "YogieBear@yahoo.com", InActive = null, InActiveDate = null},
                new Email {Addr = "BooBooBear@yahoo.com", InActive = null, InActiveDate = null},
                new Email {Addr = "PeterParker@yahoo.com", InActive = null, InActiveDate = null},
                new Email {Addr = "BruceWayne@yahoo.com", InActive = null, InActiveDate = null},
                new Email {Addr = "MotherHubbard@yahoo.com", InActive = null, InActiveDate = null},
                new Email {Addr = "PoorDog@yahoo.com", InActive = null, InActiveDate = null}
            };

            foreach (Email eAddr in emailAddresses) { context.Email.Add(eAddr); };
            context.SaveChanges();

            var mEmails = new MemberEmail[]
            {
                new MemberEmail { AdultId = 1, JuvenileId = null, EmailId = 1},
                new MemberEmail { AdultId = 1, JuvenileId = 1, EmailId = 2},
                new MemberEmail { AdultId = 2, JuvenileId = null, EmailId = 3},
                new MemberEmail { AdultId = 3, JuvenileId = null, EmailId = 4},
                new MemberEmail { AdultId = 4, JuvenileId = null, EmailId = 5},
                new MemberEmail { AdultId = 4, JuvenileId = 2, EmailId = 6},
            };

            foreach (MemberEmail mEmail in mEmails) { context.MemberEmail.Add(mEmail); };
            context.SaveChanges();

            var pTypes = new PhoneType[]
            {
                new PhoneType { Id = "c", Type = "Cell"},
                new PhoneType { Id = "h", Type = "Home"},
                new PhoneType { Id = "b", Type = "Business"},
                new PhoneType { Id = "f", Type = "Fax"},
            };

            foreach (PhoneType pType in pTypes) { context.PhoneType.Add(pType); };
            context.SaveChanges();

            var pNums = new Phone[]
            {
                new Phone {PhoneNum = "(206) 123-4567", InActive = null, InActiveDate = null},
                new Phone {PhoneNum = "(206) 234-5678", InActive = null, InActiveDate = null},
                new Phone {PhoneNum = "(206) 345-6789", InActive = null, InActiveDate = null},
                new Phone {PhoneNum = "(206) 456-7890", InActive = null, InActiveDate = null},
                new Phone {PhoneNum = "(206) 567-8901", InActive = null, InActiveDate = null},
                new Phone {PhoneNum = "(206) 678-9012", InActive = null, InActiveDate = null}
            };

            foreach(Phone pNum in pNums) { context.Phone.Add(pNum); };
            context.SaveChanges();

            var mPnums = new MemberPhone[]
            {
                new MemberPhone { AdultId = 1, JuvenileId = null, PhoneId = 1, PhoneTypeId = "c"},
                new MemberPhone { AdultId = 1, JuvenileId = 1, PhoneId =2, PhoneTypeId = "h"},
                new MemberPhone { AdultId = 2, JuvenileId = null, PhoneId = 3, PhoneTypeId = "b"},
                new MemberPhone { AdultId = 3, JuvenileId = null, PhoneId = 4, PhoneTypeId = "f"},
                new MemberPhone { AdultId = 4, JuvenileId = null, PhoneId = 5, PhoneTypeId = "c"},
                new MemberPhone { AdultId = 4, JuvenileId = 2, PhoneId = 6, PhoneTypeId = "h"}
            };

            foreach(MemberPhone mPnum in mPnums) { context.MemberPhone.Add(mPnum); };
            context.SaveChanges();

            var lLogins = new LibraryLogin[] 
            {
                new LibraryLogin { UserId = "gReeper", UserPw = "ZoopBooDaBoop", PwupdateDate = DateTime.Parse("1971-06-14 12:00"), PwexpirationDate = DateTime.Parse("2081-06-14 12:00"), AccountLockout = null}
            };

            foreach(LibraryLogin lLogin in lLogins) { context.LibraryLogin.Add(lLogin); };
            context.SaveChanges();            
        }
    }
}
