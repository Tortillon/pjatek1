using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    public Name name;
    public TextMeshProUGUI banned;


    public UnityEvent onLongClick;
    public UnityEvent onRelease;


    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        onLongClick?.Invoke();
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        onRelease?.Invoke();
        Debug.Log("OnPointerUp");
    }

   

    private void Reset()
    {
        pointerDown = false;
        onRelease?.Invoke();
    }


}