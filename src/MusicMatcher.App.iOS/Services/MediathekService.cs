using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CoreGraphics;
using MediaPlayer;
using MusicMatcher.Common;

namespace MusicMatcher.App.iOS
{
    internal class MediathekService : IMediathekService
    {
        public async Task<Song[]> LoadAllSongsAsync()
        {
            if (ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.SIMULATOR)
            {
                return await GetCsvDataAsync().ConfigureAwait(false);
            }

            var request = await MPMediaLibrary.RequestAuthorizationAsync();

            if (request != MPMediaLibraryAuthorizationStatus.Authorized)
            {
                return new List<Song>().ToArray();
            }

            var imageSize = new CGSize(50, 50);

            MPMediaQuery allSongs = MPMediaQuery.SongsQuery;

            var result = allSongs.Items.Select(item => new Song
            {
                Titel = item.Title,
                Album = item.AlbumTitle,
                Artist = item.Artist,
                Year = item.ReleaseDate.ToString(),
                Rating = item.Rating.ToString(),
                Image = item.Artwork.ImageWithSize(imageSize).AsPNG().ToArray()
            }).ToArray();

            return result;
        }

        private static async Task<Song[]> GetCsvDataAsync()
        {
            var result = new List<Song>();

            using (var fs = File.OpenRead("Titel.csv"))
            using (var reader = new StreamReader(fs))
            {
                bool isFirstRow = true;
                while (!reader.EndOfStream)
                {
                    string line = await reader.ReadLineAsync().ConfigureAwait(false);

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }

                    if (isFirstRow)
                    {
                        isFirstRow = false;
                        continue;
                    }

                    var values = line.Split(';');

                    var song = new Song
                    {
                        Titel = values[0],
                        Artist = values[1],
                        Year = values[2],
                        Rating = values[3],
                        Album = values[4]
                    };

                    result.Add(song);
                }
            }

            return result.ToArray();
        }
    }
}