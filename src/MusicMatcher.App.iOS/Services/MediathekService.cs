using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreGraphics;
using MediaPlayer;
using MusicMatcher.Common;
using ObjCRuntime;

namespace MusicMatcher.App.iOS
{
    internal class MediathekService : IMediathekService
    {
        public async Task<List<Song>> ReadAllSongsAsync()
        {
            if (Runtime.Arch == Arch.SIMULATOR)
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
    }
}