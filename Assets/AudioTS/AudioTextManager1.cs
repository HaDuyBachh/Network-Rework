using System;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.Serialization;

[System.Serializable]
//public class AnimationAudioTextPair
//{
//    public AudioClip audioClip;
//    public string text;
//    public RuntimeAnimatorController animation;
//}

public class AudioTextManager1 : MonoBehaviour
{
    //[FormerlySerializedAs("AudioTextPairs")] public AnimationAudioTextPair[] audioTextPairs;
    //[FormerlySerializedAs("TextMeshProUGUI")] public TextMeshProUGUI textMeshProUGUI;
    //public GameObject robot;
    //private AudioSource audioSource;
    //public int currentIndex = 0;
    //public RuntimeAnimatorController defaultAnimation;
    //void Start()
    //{
    //    audioSource = GetComponent<AudioSource>();
    //    PlayAudioClipAtIndex(0);
    //}

    //public void PlayAudioClipAtIndex(int index)
    //{
    //    if (index >= 0 && index < audioTextPairs.Length)
    //    {
    //        AnimationAudioTextPair pair = audioTextPairs[index];
    //        audioSource.PlayOneShot(pair.audioClip);
    //        textMeshProUGUI.SetText(pair.text);
    //        robot.GetComponent<Animator>().runtimeAnimatorController = pair.animation;
    //        currentIndex = index;
    //    }
    //}

    //public void PlayNextAudioClip()
    //{
    //    currentIndex++;
    //    if (currentIndex >= 4)
    //    {
    //        // currentIndex = currentIndex - 1;
    //        audioSource.Stop(); // Reset to the first index if at the end of the array
    //        robot.GetComponent<Animator>().runtimeAnimatorController = defaultAnimation;
    //    } else {
    //        PlayAudioClipAtIndex(currentIndex);
    //    }

    //}

    //public void UpdateDisplayedText(string text)
    //{
    //    textMeshProUGUI.SetText(text);
    //}
    //void Update()
    //{
    //    if (!audioSource.isPlaying)
    //    {
    //        PlayNextAudioClip();
    //    }
    //}
}