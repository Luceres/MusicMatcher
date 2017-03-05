using System;
using System.Runtime.Serialization;
using ReactiveUI;

namespace MusicMatcher.App.iOS
{
    [DataContract]
    public class AppState : ReactiveObject
    {
        [DataMember]
        public Guid SavedGuid { get; set; }

        public AppState()
        {
            SavedGuid = Guid.NewGuid();
        }
    }
}

