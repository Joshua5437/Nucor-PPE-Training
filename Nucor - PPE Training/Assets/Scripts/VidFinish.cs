using UnityEngine;
using UnityEngine.UI;

public class VidFinish : MonoBehaviour
{
    private bool FirstPlayFlag = true;
    public GameObject CurrentVideoImageGameobject;
    public UnityEngine.Video.VideoPlayer CurrentVideo, NextVideo;

    void Update()
    {
        if (!CurrentVideo.isPlaying && FirstPlayFlag && (CurrentVideoImageGameobject.activeSelf == false))
        {
            NextVideo.Play();
            CurrentVideoImageGameobject.SetActive(false);
        }
        else {
        }
    }
}
