using UnityEngine.Audio;
using System.Collections;
using System;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;
			s.source.spatialBlend = s.spatialBlend;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	private void Start()
	{
		instance.Play("Theme", 1f);
	}

	public void Play(string sound, float delay = 0f)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + sound + " not found!");
			return;
		}

        if (s.source.isPlaying)
        {
			Debug.LogWarning("Sound: " + sound + " already playing!");
			return;
        }

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.PlayDelayed(delay);
	}

	public void PlayOnce(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + sound + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.PlayOneShot(s.clip, s.volume);
	}

	public void StopPlaying(string sound, bool fade = true)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if(fade)
			StartCoroutine(Fade(s));
		else
			s.source.Stop();
	}

	private IEnumerator Fade(Sound s)
    {
		Tween soundTween = DOTween.To(() => s.source.volume, x => s.source.volume = x, 0, 1f);
		yield return soundTween.WaitForCompletion();
		s.source.Stop();
	}

}