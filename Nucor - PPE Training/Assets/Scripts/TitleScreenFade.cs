using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenFade : MonoBehaviour
{
    public float Duration = 1.0f;
    public UnityEngine.Video.VideoPlayer IntroductionClip;
    public RawImage TitleImage;

    private void Awake()
    {
        var canvGroup = TitleImage.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));
    }

    private IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;
        yield return new WaitForSeconds(10);     // Waits for the title screen video to finish playing. 

        while (counter < Duration)               // Fades title screen.
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, (counter / Duration));
            yield return null;
        }
        IntroductionClip.Play();   // Plays after the title sequence has ended.
    }
}
