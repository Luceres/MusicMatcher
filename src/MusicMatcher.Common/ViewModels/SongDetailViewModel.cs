using ReactiveUI;

namespace MusicMatcher.Common
{
    internal class SongDetailViewModel : ReactiveObject, ISongDetailViewModel
    {
        private Song _song;
        public Song Song
        {
            get { return _song; }
            set { this.RaiseAndSetIfChanged(ref _song, value); }
        }

        public SongDetailViewModel()
        {
        }
    }
}
