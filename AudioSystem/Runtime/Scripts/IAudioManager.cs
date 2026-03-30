using System.Collections.Generic;
using UnityEngine.Audio;

namespace UralHedgehog.Audio
{
    public interface IAudioManager
    {
        public AudioMixerGroup AmgMusic { get; }
        public AudioMixerGroup AmgSound { get; }
        public AudioMixerGroup AmgVoice { get; }
        
        public List<TrackMusic> Musics { get; }
        public List<TrackSound> Sounds { get; }
        public List<TrackVoice> Voices { get; }
    }
}