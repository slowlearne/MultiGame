using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public static string folderName;
    public GameObject panel;
    public Button PopIn;
    public Button KeyButton;
    public Button GrandPianoButton;
    public Button ElectricPianoButton;
    public Button DoublePianoButton;
    public GameObject DoublePianoStorer, MainPanelStorer;

    private void Start()
    {
        // Attach button click listeners
        folderName = "GrandPiano";  
        KeyButton.onClick.AddListener(OnKeyClicked);
        GrandPianoButton.onClick.AddListener(OnGrandPianoClicked);
        ElectricPianoButton.onClick.AddListener(OnElectricPianoClicked);
        DoublePianoButton.onClick.AddListener(openDoublePianoPanel);
        PopIn.onClick.AddListener(ClosePanel);
        GetComponent<Button>().onClick.AddListener(OpenPanel);
    }

    public void OpenPanel()
    {
        // Show the panel and options
        panel.SetActive(true);
    }
    public void ClosePanel()
    {
        // Show the panel and options
        panel.SetActive(false);
    }

    public void OnKeyClicked()
    {
        DoublePianoStorer.SetActive(false);
        MainPanelStorer.SetActive(true);
        GameObject currentGameobject = EventSystem.current.currentSelectedGameObject;
        currentGameobject.transform.parent.gameObject.SetActive(false);
         folderName = "Keys";
    }

    public void OnGrandPianoClicked()
    {
        DoublePianoStorer.SetActive(false);
        MainPanelStorer.SetActive(true);
        GameObject currentGameobject = EventSystem.current.currentSelectedGameObject;
        folderName = "GrandPiano";
        currentGameobject.transform.parent.gameObject.SetActive(false);

    }

    public void OnElectricPianoClicked()
    {
        DoublePianoStorer.SetActive(false);
        MainPanelStorer.SetActive(true);
        GameObject currentGameobject = EventSystem.current.currentSelectedGameObject;
        folderName = "ElectricPiano";
        currentGameobject.transform.parent.gameObject.SetActive(false);


    }
    public void openDoublePianoPanel()
    {
        MainPanelStorer.SetActive(false);
        DoublePianoStorer.SetActive(true);
        GameObject currentGameobject = EventSystem.current.currentSelectedGameObject;
        currentGameobject.transform.parent.gameObject.SetActive(false);
    }

}
