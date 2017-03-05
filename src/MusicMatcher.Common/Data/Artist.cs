using ReactiveUI;

namespace MusicMatcher.Common
{
    internal class Artist : ReactiveObject, IArtist
    {
        public string Name { get; set; }
    }
}
