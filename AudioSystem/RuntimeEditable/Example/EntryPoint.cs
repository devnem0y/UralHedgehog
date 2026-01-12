using UnityEngine;
using UnityEngine.Audio;

namespace UralHedgehog.Audio
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioResources _audioResources;
        [SerializeField] private AudioComponent _audio;

        private void Awake()
        {
            new AudioManager(_audioMixer, _audioResources);
            _audio.Init();
        }

        private void Start()
        {
            _audio.Play(Music.MUSIC_MENU);
        }
    }
}


