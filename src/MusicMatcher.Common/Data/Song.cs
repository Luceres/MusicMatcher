using ReactiveUI;

namespace MusicMatcher.Common
{
    public class Song : ReactiveObject
    {
        public string Titel { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public byte[] Image { get; set; }
        public string Rating { get; set; }
        public string Artist { get; set; }
    }
}
