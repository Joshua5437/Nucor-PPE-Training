using UnityEngine;
using UnityEngine.UI;

public class VidFinish : MonoBehaviour
{
    public GameObject CurrentVideoImageGameobject;
    public UnityEngine.Video.VideoPlayer CurrentVideo, NextVideo;

    void Update()
    {
        if (!CurrentVideo.isPlaying && (CurrentVideoImage.activeSelf == false))
        {
            NextVideo.Play();
            CurrentVideoImage.SetActive(false);
        }
        else {
        }
    }
}
