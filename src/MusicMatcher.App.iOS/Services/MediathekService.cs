using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreAnimation;
using CoreGraphics;
using CsvHelper;
using CsvHelper.Configuration;
using MediaPlayer;
using MusicMatcher.Common;
using ObjCRuntime;

namespace MusicMatcher.App.iOS
{
    internal class MediathekService : IMediathekService
    {
        public async Task<IEnumerable<Song>> ReadAllSongsAsync()
        {
            if (Runtime.Arch == Arch.SIMULATOR)
            {
                return GetCsvData();
            }

            var request = await MPMediaLibrary.RequestAuthorizationAsync();

            if (request != MPMediaLibraryAuthorizationStatus.Authorized)
            {
                return new List<Song>();
            }

            CGSize imageSize = new CGSize(50, 50);

            MPMediaQuery allSongs = MPMediaQuery.SongsQuery;

            var result = allSongs.Items.Select(item => new Song
            {
                Titel = item.Title,
                Album = item.AlbumTitle,
                Artist = item.Artist,
                Year = item.ReleaseDate.ToString(),
                Rating = item.Rating.ToString(),
                Image = item.Artwork.ImageWithSize(imageSize).AsPNG().ToArray()
            }).ToList();

            return result;
        }

        private static List<Song> GetDummyData()
        {
            return new List<Song>
            {
                new Song
                {
                    Titel = "Blue Train",
                    Artist = "John Coltrane",
                    Album = "Blue Train",
                    Rating = "5",
                    Image = null,
                    Year = "1957"
                }
            };
        }

        private static Song[] GetCsvData()
        {
            CsvConfiguration config = new CsvConfiguration
            {
                Delimiter = ";"
            };

            var da = File.Exists("Titel.csv");

            CsvReader csv = new CsvReader(new StreamReader("Titel.csv"), config);

            var result = new List<Song>();
            while (csv.Read())
            {
                result.Add(csv.GetRecord<Song>());  
            }

            return result.ToArray();
        }
    }
}