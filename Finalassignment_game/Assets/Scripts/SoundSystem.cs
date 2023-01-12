using UnityEngine;

namespace YIZU
{

    [RequireComponent(typeof(AudioClip))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip sound)
        {
            aud.PlayOneShot(sound);
        }
    }
}