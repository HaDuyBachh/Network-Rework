using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

[System.Serializable]
public class AnimationAudioTextPair
{
    public AudioClip audioClip;
    public string text;
    public Animation animation;
}

public class AudioTextManager : MonoBehaviour
{
    [FormerlySerializedAs("AudioTextPairs")] public AnimationAudioTextPair[] audioTextPairs;
    [FormerlySerializedAs("TextMeshProUGUI")] public TextMeshProUGUI textMeshProUGUI;

    private AudioSource audioSource;
    public int currentIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayAudioClipAtIndex(0);
    }

    private void Update()
    {
        if (!audioSource.isPlaying && currentIndex < 3)
        {
            PlayNextAudioClip();
        }    
    }

    public void PlayAudioClipAtIndex(int index)
    {
        if (index >= 0 && index < audioTextPairs.Length)
        {
            audioSource.Stop();
            AnimationAudioTextPair pair = audioTextPairs[index];
            audioSource.PlayOneShot(pair.audioClip);
            textMeshProUGUI.SetText(pair.text);
            currentIndex = index;
        }
    }

    public void PlayNextAudioClip()
    {
        currentIndex++;
        if (currentIndex >= audioTextPairs.Length)
        {
            currentIndex = 0; // Reset to the first index if at the end of the array
        }

        PlayAudioClipAtIndex(currentIndex);
    }

    public void UpdateDisplayedText(string text)
    {
        textMeshProUGUI.SetText(text);
    }
}