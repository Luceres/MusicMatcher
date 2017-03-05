using System;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using MusicMatcher.Common.Data;
using ReactiveUI;

namespace MusicMatcher.Common
{
    internal class ArtistListViewModel : ReactiveObject, IArtistListViewModel
    {
        private readonly ReactiveList<IArtist> _artists;

        public ArtistListViewModel()
        {
            _artists = new ReactiveList<IArtist>();

            LoadListCommand = ReactiveCommand.CreateFromTask(LoadListAsync);

            LoadListCommand.ThrownExceptions.Subscribe(ex =>
                {
                    Debug.WriteLine(ex.Message);
                }
            );
        }

        public ReactiveCommand<Unit, Unit> LoadListCommand { get; }

        private async Task LoadListAsync()
        {
            IDataService dataService = new DataService();

            // Mit .ConfigureAwait(false) geht das nicht!
            var artists = await dataService.LoadAllArtistsAsync(500).ConfigureAwait(true);
    
            _artists.AddRange(artists);
        }

        public ReactiveList<IArtist> Artists => _artists;
    }
}
