using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveAudioManager : MonoBehaviour
{
    public static ObjectiveAudioManager Instance;

    [System.Serializable]
    public class ObjectiveAudio
    {
        public string objectiveName;
        public AudioClip[] audioClips;
    }

    public ObjectiveAudio[] objectiveAudios;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void PlayObjectiveAudio(string objectiveName, int clipIndex = 0)
    {
        ObjectiveAudio audioData = System.Array.Find(objectiveAudios, o => o.objectiveName == objectiveName);
        if (audioData == null || clipIndex < 0 || clipIndex >= audioData.audioClips.Length)
        {
            return;
        }

        audioSource.clip = audioData.audioClips[clipIndex];
        audioSource.Play();
    }

    public void Stop(string objectiveName)
    {
        ObjectiveAudio audioData = System.Array.Find(objectiveAudios, o => o.objectiveName == objectiveName);
        if (audioData == null || audioSource.clip != audioData.audioClips[0])
        {
            return;
        }
        audioSource.Stop();
    }

    public bool IsPlaying(string objectiveName)
    {
        ObjectiveAudio audioData = System.Array.Find(objectiveAudios, o => o.objectiveName == objectiveName);
        if (audioData == null) return false;

        return audioSource.clip == audioData.audioClips[0] && audioSource.isPlaying;
    }
}
