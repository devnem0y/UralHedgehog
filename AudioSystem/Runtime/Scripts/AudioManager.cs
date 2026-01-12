using System.Collections.Generic;
using UnityEngine.Audio;

namespace UralHedgehog.Audio
{
    public class AudioManager
    {
        private const string MASTER = "Master";
        private const string MUSIC = "Music";
        private const string SOUND = "Sound";
        private const string VOICE = "Voice";

        private static AudioMixer _audioMixer;

        public static AudioMixerGroup AmgMusic => AMG(MUSIC);
        public static AudioMixerGroup AmgSound => AMG(SOUND);
        public static AudioMixerGroup AmgVoice => AMG(VOICE);
        
        public static List<TrackMusic> Musics { get; private set; }
        public static List<TrackSound> Sounds { get; private set; }
        public static List<TrackVoice> Voices { get; private set; }

        public AudioManager(AudioMixer audioMixer, AudioResources audioResources)
        {
            _audioMixer = audioMixer;

            Musics = audioResources.Musics;
            Sounds = audioResources.Sounds;
            Voices = audioResources.Voices;
        }

        private static AudioMixerGroup AMG(string nameGroup)
        {
            return nameGroup switch
            {
                MUSIC => _audioMixer.FindMatchingGroups(MASTER)[1],
                SOUND => _audioMixer.FindMatchingGroups(MASTER)[2],
                VOICE => _audioMixer.FindMatchingGroups(MASTER)[3],
                _ => null
            };
        }
    }
}