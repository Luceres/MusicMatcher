using System;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using MusicMatcher.Common.Data;
using ReactiveUI;
using Splat;

namespace MusicMatcher.Common
{
    internal class MediathekViewModel : ReactiveObject, IMediathekViewModel
    {
        private readonly ReactiveList<Artist> _artists;
        private readonly ReactiveList<Song> _songs;
        private readonly IDataService _dataService;

        public MediathekViewModel()
        {
            _dataService = new DataService(Locator.Current.GetService<IMediathekService>());
            _artists = new ReactiveList<Artist>();
            _songs = new ReactiveList<Song>();

            LoadArtistsCommand = ReactiveCommand.CreateFromTask(LoadArtistsAsync);
            LoadArtistsCommand.ThrownExceptions.Subscribe(ex =>
                {
                    Debug.WriteLine(ex.Message);
                }
            );

            LoadSongsCommand = ReactiveCommand.CreateFromTask(LoadSongsAsync);
            LoadSongsCommand.ThrownExceptions.Subscribe(ex =>
            {
                Debug.WriteLine(ex.Message);
            }
            );
        }
                
        public ReactiveCommand<Unit, Unit> LoadArtistsCommand { get; }

        public ReactiveCommand<Unit, Unit> LoadSongsCommand { get; }

        private async Task LoadArtistsAsync()
        {          
            // Mit .ConfigureAwait(false) geht das nicht!
            var artists = await _dataService.LoadAllArtistsAsync(500).ConfigureAwait(true);
    
            _artists.AddRange(artists);
        }

        private async Task LoadSongsAsync()
        {
            // Mit .ConfigureAwait(false) geht das nicht!
            var songs = await _dataService.LoadAllSongsAsync().ConfigureAwait(true);

            _songs.AddRange(songs);
        }

        public ReactiveList<Artist> Artists => _artists;

        public ReactiveList<Song> Songs => _songs;
    }
}
