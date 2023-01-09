using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineBookLibrary.Models;
using System;
using System.Linq;

namespace OnLineBookLibrary.models;

public static class SeedData
{
    public static void initialize(IServiceProvider serviceprovider)
    {
        using (var context = new OnlineBookLibraryDataContext(
            serviceprovider.GetRequiredService<
                DbContextOptions<OnlineBookLibraryDataContext>>()))
        {

            if (context.Users.Any())
            {
               /* return;*/   // db has been seeded
            }

            var users = new User[]
            {
                 new User
                {

                    UserName = "Dinh Quang Anh",
                    RoleId = 3,
                    Address = "Ninh Binh",
                    Phone = "0395100761",
                    Email = "anhdinh@fpt.edu.vn",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456")
                },
                new User {

					UserName = "Nguyen Ba Khanh",
					RoleId = 2,
					Address = "Ha Noi",
					Phone = "0395100761",
					Email = "khanhnguyen@fpt.edu.vn",
					Password = BCrypt.Net.BCrypt.HashPassword("123456")
				},
                new User {

					UserName = "Luong Viet Hoang",
					RoleId = 1,
					Address = "Binh Duong",
					Phone = "0395100761",
					Email = "hoangluong@fpt.edu.vn",
					Password = BCrypt.Net.BCrypt.HashPassword("123456")
				}
            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var genres = new Genre[]
            {
                new Genre { GenreName = "Novel" },
                new Genre { GenreName = "Comic" },
                new Genre { GenreName = "Manga" },
                new Genre { GenreName = "Haiten" },
                new Genre { GenreName = "Autobiography" },
                new Genre { GenreName = "Fairy Tales" },
				new Genre { GenreName = "Fables" },
				new Genre { GenreName = "Detective" }
			};
            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();

            var books = new Book[]
            {
				// Comic
                new Book
                {

                    Title = "Sin City",
                    Author = "Frank Miller",
                    Description = "His work with Batman and Daredevil is typically first to come to mind as writer and artist Frank Miller's best comics, but he's also written some classic non-superhero stories. Dark Horse's Sin City is an acclaimed neo-noir story set in a bleak, authoritarian-run town in the United States. The comic was revered for its approach and heavy inspiration from pulp and crime-noir TV, movie, and magazine stories.",
                    Image = "Sin_City",
                    Price = 9.99,
                    Status = "Stocking",
                    GenreId = genres.Single(g => g.GenreName == "Comic").GenreId
                },
				new Book
				{

					Title = "Preacher",
					Author = "Jesse Custer",
					Description = "As one of the comic book industry's 'big two' publishers, DC Comics is primarily known for its best superheroes. However, their Vertigo imprint of comics spawned some timeless non-superhero classics. Garth Ennis and Steve Dillon's Preacher was one such cult-hit, with the story centered around a grim supernatural/religious disaster plaguing a small Texas town.",
					Image = "Precher",
					Price = 99.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Comic").GenreId
				},
				new Book
				{

					Title = "Kingdom Come",
					Author = "Mark Waid",
					Description = "Expanding to the greater Justice League, Kingdom Come is a landmark comic in DC's pantheon of stories. This alternate-canon comic was a sort of meta deconstruction of \"superheroes\" as a concept. Veteran writer Mark Waid and iconic artist Alex Ross put together a miniseries that detailed the fall in prominence of the outdated \"traditional\" heroes and the rise of dangerous copycats.",
					Image = "Kingdom_Come",
					Price = 19.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Comic").GenreId
				},
				new Book
				{

					Title = "The Sandman",
					Author = "Neil Gaiman",
					Description = "The most iconic Vertigo series that DC published was its flagship The Sandman, written by the great Neil Gaiman and illustrated by numerous artists. The story revolves around Dream, one of the seven Endless, finding himself captured by cultists and forced to acknowledge that even entities that are even stronger than DC's gods such as them need to accept inevitable change.",
					Image = "The_Sandman",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Comic").GenreId
				},

				// Novel
				new Book
				{

					Title = "ULYSSES",
					Author = "James Joyce",
					Description = "Written as an homage to Homer’s epic poem The Odyssey, Ulysses follows its hero, Leopold Bloom, through the streets of Dublin. Overflowing with puns, references to classical literature, and stream-of-consciousness writing, this is a complex, multilayered novel about one day in the life of an ordinary man. Initially banned in the United States but overturned by a legal challenge by Random House’s Bennett Cerf, Ulysses was called “a memorable catastrophe” (Virginia Woolf), “a book to which we are all indebted” (T. S. Eliot), and “the most faithful X-ray ever taken of the ordinary human consciousness” (Edmund Wilson). Joyce himself said, “There is not one single serious line in [Ulysses].",
					Image = "ULYSSES",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Novel").GenreId
				},
				new Book
				{

					Title = "THE GREAT GATSBY",
					Author = "F. Scott Fitzgerald",
					Description = "Set in the Jazz Age, The Great Gatsby tells the story of the mysterious millionaire Jay Gatsby, his decadent parties, and his love for the alluring Daisy Buchanan. Dismissed as “no more than a glorified anecdote, and not too probable at that” (The Chicago Tribune), The Great Gatsby is now considered a contender for “the Great American Novel.” Fitzgerald wanted to title the novel “Trimalchio in West Egg,” but both his wife and his editor preferred “The Great Gatsby.” Fitzgerald gave in, though he still thought that “the title is only fair, rather bad than good.”",
					Image = "The_Great_Gatsby",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Novel").GenreId
				},
				new Book
				{

					Title = "LOLITA",
					Author = "Vladimir Nabokov",
					Description = "Lolita tells the story of middle-aged Humbert Humbert’s love for twelve-year-old Dolores Haze. The concept is troubling, but the novel defies any kind of label, though it has been heralded as a hilarious satire, a bitter tragedy, and even an allegory for U.S.-European relations. In Reading Lolita in Tehran, Azar Nafisi summarized the book as “hopeful, beautiful even, a defense not just of beauty but of life . . . Nabokov, through his portrayal of Humbert, has exposed all solipsists who take over other people’s lives.”",
					Image = "Lolita",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Novel").GenreId
				},
				new Book
				{

					Title = "CATCH-22",
					Author = "Joseph Heller",
					Description = "This satirical novel follows U.S. Captain John Yossarian and his squadron of World War II fighters as they navigate the horrors and paradoxes of war. Based on American author Joseph Heller’s own wartime experiences, the novel explores the many facets of war and employs a unique narrative structure. Catch-22 is widely seen as one of the most significant American novels of the twentieth century.",
					Image = "Catch_22",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Novel").GenreId
				},
				new Book
				{

					Title = "I, CLAUDIUS",
					Author = "Robert Graves",
					Description = "A classic of historical fiction, this book is the fictionalized autobiography of the Roman Emperor Claudius, born partially deaf and afflicted with a limp, and his rise to power. Along the way, you see the inner workings of the First Family of Rome and the vicious, murderous in-fighting and poisonings that Claudius—considered too stupid, lame, and ugly to fear—observes.",
					Image = "I_Claudius",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Novel").GenreId
				},
				// Manga
				new Book
				{

					Title = "One Piece",
					Author = "Eiichiro Oda",
					Description = "One Piece (ワンピース), which has been serialized on Weekly Shonen Jump since 1997, is the best manga of all time, which almost nobody can disagree with. 96 volumes have been published and totally about 470 million copies are sold worldwide. It has been translated into foreign languages in more than 40 countries and regions.",
					Image = "One_Piece",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Manga").GenreId
				},
				new Book
				{

					Title = "Naruto",
					Author = "Masashi Kishimoto",
					Description = "For one of the most famous and popular manga worldwide, a huge range of manga fans and otaku agree with Naruto (ナルト), the Ninja-themed manga. Naruto was serialized on Weekly Shonen Jump for about 15 year from 1999, and totally 72 volumes with 700 chapters were published. As of 2019, about 250 million copies were sold all over the world.",
					Image = "Naruto",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Manga").GenreId
				},
				new Book
				{

					Title = "Dragon Ball",
					Author = "Akira Toriyama",
					Description = "Speaking of the history of manga, you cannot avoid talking about Dragon Ball (ドラゴンボール). The action and adventure manga was serialized on Weekly Shonen Jump for about a decade from 1984, which contributed to the flourishing age of the Japanese comic book magazine brand in 1990s and even the whole manga industry.",
					Image = "Dragon_Ball",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Manga").GenreId
				},
				new Book
				{

					Title = "Tokyo Ghoul",
					Author = "Sui Ishida",
					Description = "Tokyo Ghoul (東京喰種トーキョーグール) is a popular dark fantasy manga, serialized on Weekly Young Jump from 2011 to 2014 and followed by the sequel title Tokyo Ghoul:re (東京喰種トーキョーグール:re) until 2018. The setting is Tokyo where the creatures called Ghouls live in the human society. They look like a normal human but subsist on human flesh as food. Its anime adaption is also loved by the fans all over the world.",
					Image = "Tokyo_Ghoul",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Manga").GenreId
				},
				// Autobiography
				new Book
				{

					Title = "The Collected Autobiographies of Maya Angelou",
					Author = "Maya Angelou",
					Description = "Maya Angelou’s I Know Why the Caged Bird Sings is one of the most acclaimed and recommended memoirs and one of the best books for women. It focuses on the author’s childhood and became the first of seven books chronicling the author’s remarkable life and insight.",
					Image = "maya_angelou_autobiography_via_amazon",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Autobiography").GenreId
				},
				new Book
				{

					Title = "The Autobiography of Benjamin Franklin",
					Author = "Benjamin Franklin",
					Description = "The Autobiography of Benjamin Franklin details the Founding Father‘s early life and unique adulthood. One of the book’s most notable sections describes Franklin’s attempts to achieve “moral perfection” through the achievement of 13 virtues, including temperance, silence, and order.",
					Image = "the_autobiography_of_Benjamin_Franklin_via_amazon",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Autobiography").GenreId
				},
				new Book
				{

					Title = "Narrative of the Life of Frederick Douglass",
					Author = "Benjamin Franklin",
					Description = "This historic work of nonfiction is widely considered to be one of the best autobiographies ever written. It’s a vivid retelling of Douglass’ childhood and the torturous abuse he suffered at the hands of numerous slave-owners, as well as his harrowing escape to freedom, after which he became a respected orator and prominent abolitionist.",
					Image = "narrative_of_the_life_of_frederick_douglas_via_amazon",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Autobiography").GenreId
				},
				new Book
				{

					Title = "The Diary of a Young Girl",
					Author = "Anne Frank",
					Description = "This autobiography, one of the most famous books about the Holocaust, takes the form of a collection of writings from the diary Anne Frank kept for the two years she was in hiding with her family during the Nazi occupation of the Netherlands. In daily writings, Frank shares intimate details about her family, crushes on boys, her religion, and the heartbreaking effects of the war",
					Image = "the_diary_of_anne_frank_via_amazon_1",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Autobiography").GenreId
				},
				// Fairy Tales
				new Book
				{

					Title = "Cinderella",
					Author = "The Brother Grimm",
					Description = "Cinderella is one of the most popular fairy tales of all time. Its story remains an all-time classic and will remain the same for future generations as well.",
					Image = "Cindrella",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fairy Tales").GenreId
				},
				new Book
				{

					Title = "Beauty and the Beast",
					Author = "Jenne Marie",
					Description = "Beauty and the Beast is a fairy tale that celebrates real royalty. In the story, a spoiled prince turns into a beast and imprisons a beautiful young lady named Belle. It’s only when he learns to love Belle that he becomes the prince again.",
					Image = "beauty-and-the-beast",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fairy Tales").GenreId
				},
				new Book
				{

					Title = "Rapunzelt",
					Author = "Unknown",
					Description = "Rapunzel is a beautiful and motivational fairy tale. The story shows how a poor couple lost their daughter Rapunzel when they stole fruit from their neighbor’s garden. It also focuses on how the angelic voice of Rapunzel reunites her with her lover.",
					Image = "Rapunzel",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fairy Tales").GenreId
				},
				new Book
				{

					Title = "Snow White and the Seven Dwarfs",
					Author = "Unknown",
					Description = "Snow White is a young princess and is defined by her inherent kindness and pure beauty. In the story, an evil queen spends all her life envying Snow White’s beauty.But, in the end, Snow White finds her happiness by marrying the prince. In contrast, the evil queen loses her peace and leads an unhappy life while chasing meaningless physical beauty.",
					Image = "Snow-white",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fairy Tales").GenreId
				},
				// Fables
				new Book
				{

					Title = "Aesop’s Fables (The Classic Edition)",
					Author = "Charles Santore",
					Description = "Revive your childhood wonder and fascination with the most exquisitely illustrated edition of Aesop’s Fables to hit the market in years—featuring breathtaking original artwork by #1 New York Times bestselling illustrator Charles Santore!",
					Image = "Aesop",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fables").GenreId
				},
				new Book
				{

					Title = "Animal Farm",
					Author = "George Orwell",
					Description = "Animal Farm is a satirical allegorical novella by George Orwell, first published in England on 17 August 1945. The book tells the story of a group of farm animals who rebel against their human farmer, hoping to create a society where the animals can be equal, free, and happy. Ultimately, the rebellion is betrayed, and the farm ends up in a state as bad as it was before, under the dictatorship of a pig named Napoleon.",
					Image = "Animal_farm",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fables").GenreId
				},
				new Book
				{

					Title = "Fables",
					Author = "Arnold Lobel",
					Description = "Fables is a children's picture book by American author Arnold Lobel. Released by Harper & Row in 1980, it was the recipient of the Caldecott Medal for illustration in 1981.",
					Image = "Fables",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fables").GenreId
				},
				new Book
				{

					Title = "Friedman’s Fables",
					Author = "Edwin H. Friedman",
					Description = "Edwin H. Friedman has woven 24 illustrative tales that offer fresh perspectives on familiar human foibles and reflect the author's humor, pathos, and understanding. Friedman takes on resistance and other \"demons\" to show that neither insight, nor encouragement, nor intimidation can in themselves motivate an unmotivated person to change. These tales playfully demonstrate that new ideas, new questions, and imagination, more than accepted wisdom, provide each of us with the keys to overcoming stubborn emotional barriers and facilitating real change both in ourselves and others. Thought-provoking discussion questions for each fable are included.",
					Image = "friedman-s-fables",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Fables").GenreId
				},
				// Detective
				new Book
				{

					Title = "THE CROSSING",
					Author = "MICHAEL CONNELLY",
					Description = "In one of the most recent entries in Michael Connelly’s bestselling series featuring LAPD Detective Harry Bosch, the now-retired investigator teams up with his half-brother, Mickey Haller, the protagonist of another of Connelly’s long-running series of crime novels.",
					Image = "the_crossing",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Detective").GenreId
				},
				new Book
				{

					Title = "A BANQUET OF CONSEQUENCES",
					Author = "ELIZABETH GEORGE",
					Description = "The aristocratic Inspector Thomas Lynley and his brilliant but exasperating partner at New Scotland Yard, Detective Barbara Havers, become embroiled in a murder mystery involving a famous feminist author.",
					Image = "a_banquet_of_consequences",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Detective").GenreId
				},
				new Book
				{

					Title = "A MAN WITHOUT BREATH",
					Author = "PHILIP KERR",
					Description = "Philip Kerr’s Bernie Gunther novels are all grounded in the history of Nazi Germany. They frequently feature historical figures, many of them famous. In the ninth book of the series, Bernie conducts a wartime investigation for the German military about the 1940 massacre of 22,000 Polish officers by Josef Stalin’s NKVD.",
					Image = "a_man_without_breath-1",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Detective").GenreId
				},
				new Book
				{

					Title = "HOW IT HAPPENED",
					Author = "MICHAEL KORYTA",
					Description = "As this standalone novel opens, a young woman named Kimberly (Kimmy) Crepeaux is confessing to taking part in a pair of gruesome murders. Rob Barrett, the FBI agent sent to Maine to interview her, has finally found his patience paying off. Now, after two months of interrogating Kimmy, he understands at last what happened.",
					Image = "how_it_happened",
					Price = 109.00,
					Status = "Stocking",
					GenreId = genres.Single(g => g.GenreName == "Detective").GenreId
				},
			};
            foreach (Book b in books)
            {
                context.Books.Add(b);
            }

            context.SaveChanges();
        }
    }
}
