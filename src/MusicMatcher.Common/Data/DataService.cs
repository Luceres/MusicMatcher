using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicMatcher.Common.Data
{
    internal class DataService : IDataService
    {
        public async Task<List<IArtist>> LoadAllArtistsAsync(int slowness)
        {
            await Task.Delay(slowness).ConfigureAwait(false);

            return new List<IArtist>
            {
                new Artist {Name = "Beyouncé"},
                new Artist {Name = "Adele"},
                new Artist {Name = "Paul McCartney"},
                new Artist {Name = "Michael Jackson"},
                new Artist {Name = "Tayloer Swift"},
                new Artist {Name = "Elton John"},
                new Artist {Name = "Eminem"},
                new Artist {Name = "Katy Perry"},
                new Artist {Name = "Jay Z"},
                new Artist {Name = "David Bowie"},
                new Artist {Name = "Madonna"},
                new Artist {Name = "Rihanna"},
                new Artist {Name = "Lady Gaga"},
                new Artist {Name = "Billy Joel"},
                new Artist {Name = "Cher"},
                new Artist {Name = "Drake"},
                new Artist {Name = "Prince"},
                new Artist {Name = "Céline Dion"},
                new Artist {Name = "Nicki Minaj"},
                new Artist {Name = "Kanye West"},
                new Artist {Name = "Aretha Franklin"},
                new Artist {Name = "Justin Timberlake"},
                new Artist {Name = "Britney Spears"},
                new Artist {Name = "Mariah Carey"},
                new Artist {Name = "Stevie Wonder"},
                new Artist {Name = "Johnny Cash"},
                new Artist {Name = "Rod Stewart"},
                new Artist {Name = "Nicki Minaj"},
                new Artist {Name = "Whintey Houston"},
                new Artist {Name = "Carlos Santana"},
                new Artist {Name = "Elvis Presley"},
                new Artist {Name = "Ray Charles"},
                new Artist {Name = "The Weeknd"},
                new Artist {Name = "Miley Cyrus"},
                new Artist {Name = "Bruce Springsteen"},
                new Artist {Name = "Paul Simon"},
                new Artist {Name = "Rod Stewart"},
                new Artist {Name = "Neil Young"},
                new Artist {Name = "Bruno Mars"},
                new Artist {Name = "Bob Dylan"},
                new Artist {Name = "Lil Wayne"},
                new Artist {Name = "Phil Collins"},
                new Artist {Name = "Justin Bieber"},
                new Artist {Name = "Eric Clapton"},
                new Artist {Name = "John Lennon"},
                new Artist {Name = "Usher"},
                new Artist {Name = "Garth Brooks"},
                new Artist {Name = "George Michael"},
                new Artist {Name = "Tom Petty"},
                new Artist {Name = "Frank Sinatra"},
            };
        }
    }
}
