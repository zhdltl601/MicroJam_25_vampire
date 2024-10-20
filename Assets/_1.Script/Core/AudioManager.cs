using Game.Extension;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game
{
    [MonoSingletonUsage(MonoSingletonFlags.DontDestroyOnLoad)]
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private AudioSource audioSource;
        private static float audioGlobalVolume = 0.5f;
        protected override void Awake()
        {
            base.Awake();
            audioSource = this.GetComponentOrAdd<AudioSource>();
            audioSource.volume = audioGlobalVolume;
            audioSource.playOnAwake = false;
        }
        public void StopSound()
        {
            audioSource.Stop();
        }
        public void StopSound(float fade)
        {
            audioSource.DOFade(0, fade);
        }
        public void Play(AudioClip audioClip)
        {
            audioSource.volume = audioGlobalVolume;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        public void PlayOneShot(AudioClip audioClip)
        {
            audioSource.volume = audioGlobalVolume;
            audioSource.PlayOneShot(audioClip);
        }
        public void OnGlobalVolumeChange(Slider slider)
        {
            audioGlobalVolume = slider.value;
            audioSource.volume = audioGlobalVolume;
        }
    }
}
