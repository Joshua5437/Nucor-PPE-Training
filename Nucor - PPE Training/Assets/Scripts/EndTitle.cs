using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndTitle : MonoBehaviour
{
    private bool SecondVidStart = false;
    public GameObject InstructionBoard;
    public float Duration = 1.0f;
    public RawImage WorldBlockImage;
    public AudioSource CurrentAudio;
    public UnityEngine.Video.VideoPlayer TitleVideoPlayer;

    private void Update() {
        if(!CurrentAudio.isPlaying && !SecondVidStart && (InstructionBoard.activeSelf == true)) {
            var canvGroup = WorldBlockImage.GetComponent<CanvasGroup>();
            StartCoroutine(DoFade(canvGroup, 0, 1));
            TitleVideoPlayer.Play();
            SecondVidStart = true;
        }
        else if(!TitleVideoPlayer.isPlaying && SecondVidStart) {
            var canvGroup = WorldBlockImage.GetComponent<CanvasGroup>();
            StartCoroutine(DoFade(canvGroup, 1, 0));
        }
    }

    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));
            yield return null;
        }
    }
}
