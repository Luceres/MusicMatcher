using System;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using Splat;

namespace MusicMatcher.Common
{
    internal class MediathekViewModel : ReactiveObject, IMediathekViewModel
    {
        private readonly IMediathekService _mediathekService;

        private readonly ReactiveList<Song> _songs;

        public MediathekViewModel()
        {
            _mediathekService = Locator.Current.GetService<IMediathekService>();

            _songs = new ReactiveList<Song>();

            LoadSongsCommand = ReactiveCommand.CreateFromTask(LoadSongsAsync);
            LoadSongsCommand.ThrownExceptions.Subscribe(ex =>
            {
                Debug.WriteLine(ex.Message);
            });
        }

        public ReactiveCommand<Unit, Unit> LoadSongsCommand { get; }

        private async Task LoadSongsAsync()
        {
            // Mit .ConfigureAwait(false) geht das nicht!
            var songs = await _mediathekService.LoadAllSongsAsync().ConfigureAwait(true);

            _songs.AddRange(songs);
        }

        public ReactiveList<Song> Songs => _songs;
    }
}
