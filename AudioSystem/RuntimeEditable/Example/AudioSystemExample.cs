using UnityEngine;
using UnityEngine.Audio;

namespace UralHedgehog.Audio
{
    public class AudioSystemExample : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioResources _audioResources;
        [SerializeField] private AudioComponent _audio;

        private void Awake()
        {
            AudioUtils.SetManager(_audioMixer, _audioResources);
            _audio.Init();
        }

        private void Start()
        {
            _audio.Play(Music.MUSIC_MENU);
        }
    }
}


