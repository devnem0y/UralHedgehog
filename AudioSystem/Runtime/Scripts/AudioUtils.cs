using System;
using System.Collections.Generic;
using UnityEngine.Audio;

namespace UralHedgehog.Audio
{
    public static class AudioUtils
    {
        private const string Exception = "AudioManager не инициализирован. Вызовите SetManager() перед использованием.";
        
        private static IAudioManager _manager;
        
        public static bool HasManager => _manager != null;
        
        public static AudioMixerGroup AmgMusic => _manager?.AmgMusic;
        public static AudioMixerGroup AmgSound => _manager?.AmgSound;
        public static AudioMixerGroup AmgVoice => _manager?.AmgVoice;

        public static List<TrackMusic> Musics => _manager?.Musics;
        public static List<TrackSound> Sounds => _manager?.Sounds;
        public static List<TrackVoice> Voices => _manager?.Voices;
        
        public static IAudioManager Manager
        {
            get
            {
                if (_manager != null) return _manager;
                throw new InvalidOperationException(Exception);
            }
        }
        
        public static void SetManager(AudioMixer audioMixer, AudioResources audioResources)
        {
            _manager = new AudioManager(audioMixer, audioResources);
        }
        
        public static void SetManager(IAudioManager manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }
    }
}