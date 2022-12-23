using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class VRTutorial : MonoBehaviour
{
    public Sprite[] ControllerSprites;
    public GameObject SphereInteractable;
    public InputActionReference toggleReference = null;

    private Button Next;
    private TextMeshProUGUI Text;
    private int ToggleCounter = 0;
    private Image ControllerImage;
    private GameObject Interactable;
    private AudioSource Trigger, MenuEnter, MenuExit, Select;

    private void Awake() { toggleReference.action.started += Toggle; }
    private void OnDestroy() { toggleReference.action.started -= Toggle; }

    void Start()
    {
        Next = GameObject.Find("Next Button").GetComponent<Button>();
        Trigger = GameObject.Find("Trigger").GetComponent<AudioSource>();
        MenuEnter = GameObject.Find("MenuEnter").GetComponent<AudioSource>();
        MenuExit = GameObject.Find("MenuExit").GetComponent<AudioSource>();
        Select = GameObject.Find("Select").GetComponent<AudioSource>();
        Text = GameObject.Find("Instruction Text (TMP)").GetComponent<TextMeshProUGUI>();
        ControllerImage = GameObject.Find("Controller Image").GetComponent<Image>();

        Next.onClick.AddListener(MenuPress);
    }

    public void TriggerPress() {
        Trigger.Play();
        ControllerImage.sprite = ControllerSprites[0];
        Text.GetComponent<TextMeshProUGUI>().text = "Point to the 'Next' button and use the 'Trigger' to continue.";
    }

    private void MenuPress() {
        Trigger.Stop(); // Stops audio if it is still playing.

        MenuEnter.Play();
        ControllerImage.sprite = ControllerSprites[1];
        Text.GetComponent<TextMeshProUGUI>().text = "Press 'Menu' to continue.";
    }

    private void Toggle(InputAction.CallbackContext context) { // Triggered by pressing 'Menu'. Introduces the select button to user. 
        if (ToggleCounter == 1)
        {
            Select.Play();
            MenuExit.Stop();
            Interactable.SetActive(true);
        }
        if (ToggleCounter == 0)
        {
            MenuExit.Play();
            MenuEnter.Stop();
        }
        ControllerImage.sprite = ControllerSprites[2];
        Text.GetComponent<TextMeshProUGUI>().text = "Use grip your right controller to grab the sphere.";
        ToggleCounter++;
    }
}
