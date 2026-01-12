using System.Collections.Generic;
using UnityEngine;

namespace UralHedgehog.Audio
{
    [CreateAssetMenu(fileName = "AudioResources", menuName = "Ural Hedgehog/Audio System/AudioResources", order = 2)]
    public class AudioResources : ScriptableObject
    {
        [SerializeField] private List<TrackMusic> _musics;
        public List<TrackMusic> Musics => _musics;
        [SerializeField] private List<TrackSound> _sounds;
        public List<TrackSound> Sounds => _sounds;
        [SerializeField] private List<TrackVoice> _voices;
        public List<TrackVoice> Voices => _voices;
    }
}
