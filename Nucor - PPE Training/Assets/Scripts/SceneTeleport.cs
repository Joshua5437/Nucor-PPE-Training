using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTeleport : MonoBehaviour
{
    private bool wait = false;
    public float Duration = 2.0f;
    public string InputText;
    public Image TransitionImage;
    public AudioSource TransitionAudio;
    public TextMeshProUGUI TransitionText;
    public GameObject TeleportPoint, startingObject;

    public void TeleportUser()
    {
        // Show transition screen.
        var canvGroup = TransitionImage.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, 1, 0));

        // Teleports user. 
        GameObject User = GameObject.Find("XR Origin");
        User.transform.position = new Vector3(TeleportPoint.transform.position.x, TeleportPoint.transform.position.y, TeleportPoint.transform.position.z);
        User.transform.rotation = new Quaternion(TeleportPoint.transform.rotation.x, TeleportPoint.transform.rotation.y, TeleportPoint.transform.rotation.z, 1);

        // Tell & show the user the section they are about to go to.
        TransitionText.GetComponent<TextMeshProUGUI>().text = InputText;
        canvGroup = TransitionText.GetComponent<CanvasGroup>();
        wait = true;
        TransitionAudio.Play();                    // Verbal 
        StartCoroutine(DoFade(canvGroup, 1, 0));   // Visual  
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
        if(wait) { 
            yield return new WaitWhile(() => TransitionAudio.isPlaying);
            startingObject.SetActive(true);
        }
        
    }
}
