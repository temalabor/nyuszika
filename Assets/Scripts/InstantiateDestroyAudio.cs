using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDestroyAudio : MonoBehaviour
{
    public Sound instantiateAudio;
    public Sound destroyAudio;
    
    private void Start()
    {
        instantiateAudio.source = gameObject.AddComponent<AudioSource>(); 
        instantiateAudio.source.clip   = instantiateAudio.clip; 
        instantiateAudio.source.loop   = instantiateAudio.loop;
        instantiateAudio.source.volume = instantiateAudio.volume; 
        instantiateAudio.source.pitch  = instantiateAudio.pitch;
        
        destroyAudio.source = gameObject.AddComponent<AudioSource>(); 
        destroyAudio.source.clip   = destroyAudio.clip; 
        destroyAudio.source.loop   = destroyAudio.loop;
        destroyAudio.source.volume = destroyAudio.volume; 
        destroyAudio.source.pitch  = destroyAudio.pitch;
        
        if(instantiateAudio.clip != null) instantiateAudio.source.Play();
    }

    private void OnDestroy()
    {
        if(instantiateAudio.clip != null) AudioSource.PlayClipAtPoint(destroyAudio.clip, transform.position, destroyAudio.volume);
    }
}
