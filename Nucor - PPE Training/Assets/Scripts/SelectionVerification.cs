using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectionVerification : MonoBehaviour
{
    public Image Check, Cross;
    public float Duration = 1.0f;
    public AudioSource Correct, Incorrect;

    public void SelectionFeedback(bool response)
    {
        var canvGroup = Check.GetComponent<CanvasGroup>();
        var canvGroup2 = Cross.GetComponent<CanvasGroup>();

        if (response)
        {
            Correct.Play();
            StartCoroutine(DoFade(canvGroup, 1, 0));
        }
        else if (!response)
        {
            Incorrect.Play();
            StartCoroutine(DoFade(canvGroup2, 1, 0));
        }
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
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
