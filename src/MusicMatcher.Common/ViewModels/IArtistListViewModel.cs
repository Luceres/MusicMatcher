using System.Reactive;
using ReactiveUI;

namespace MusicMatcher.Common
{
    public interface IArtistListViewModel
    {
        ReactiveList<IArtist> Artists { get; }

        ReactiveCommand<Unit, Unit> LoadListCommand { get; }
    }
}
