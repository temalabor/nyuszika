using UnityEngine.Audio;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;

	public Movement movement;
	public Player_life life;
	
	public Sound[] sounds;


	private void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (var s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
		}

		Init();
	}

	private void Init()
	{
		var jump = Array.Find(sounds, sound => sound.name == "jump");
		if (jump != null) movement.JumpEvent += () => { if(!jump.source.isPlaying) jump.source.Play(); };
		
		var walk = Array.Find(sounds, sound => sound.name == "walk");
		if (jump != null) movement.WalkEvent += () => { if(!walk.source.isPlaying) walk.source.Play(); };
		
		var slide = Array.Find(sounds, sound => sound.name == "slide");
		if (jump != null) movement.SlideEvent += () => { if(!slide.source.isPlaying) slide.source.Play(); };
		
		var ow = Array.Find(sounds, sound => sound.name == "ow");
		if (jump != null) life.LifeEvent += (int n) => { if(!ow.source.isPlaying) ow.source.Play(); };
	}
}
