using UnityEngine;

namespace Controller
{
	public class PlayNote : MonoBehaviour
	{

		public AudioClip audioClip;
		public AudioSource audioSource;
	
		void Start () {
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = audioClip;
		}

		public void Play()
		{
			audioSource.Play();
		}
	}
}
