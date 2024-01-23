using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour, IPointerDownHandler
{
    public GameObject scrollBarStorer;
    public GameObject container;

    private Scrollbar scrollBar;
    private RectTransform containerRectTransform;
    void Start()
    {
        scrollBar = scrollBarStorer.GetComponent<Scrollbar>();
        containerRectTransform = container.GetComponent<RectTransform>();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject ScrollRectlaiRakhne = GameObject.Find("Scroll");
        ScrollRect myComponent = ScrollRectlaiRakhne.GetComponent<ScrollRect>();
        if (myComponent != null)
        {
            myComponent.enabled = true;
        }
        else
        {
            print("myComponent is inactive");
        }

    }

    private void Update()
    {
        float posXMin = 1600f;
        float posXMax = 343f;

        float mappedValue = Mathf.Lerp(posXMin, posXMax, scrollBar.value);
        containerRectTransform.anchoredPosition = new Vector2(mappedValue, containerRectTransform.anchoredPosition.y);
    }
}
