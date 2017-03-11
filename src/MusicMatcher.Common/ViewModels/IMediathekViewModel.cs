using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;

namespace MusicMatcher.Common
{
    public interface IMediathekViewModel
    {
        ReactiveList<Song> Songs { get; }

        ReactiveCommand<Unit, Unit> LoadSongsCommand { get; }
    }
}
