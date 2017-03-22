using System.Reactive;
using ReactiveUI;

namespace MusicMatcher.Common
{
    public interface IMediathekViewModel
    {
        ReactiveList<Song> Songs { get; }

        ReactiveCommand<Unit, Unit> LoadSongsCommand { get; }
        ReactiveCommand<Unit, Unit> PressTeachButtonCommand { get; }
    }
}
