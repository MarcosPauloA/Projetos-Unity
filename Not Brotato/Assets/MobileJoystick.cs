using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform joystickBG; 
    private RectTransform joystickKnob;
    private Vector2 inputVector = Vector2.zero;

    private void Start()
    {
        joystickKnob = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragPosition = eventData.position - (Vector2)joystickBG.position;
        float radius = joystickBG.sizeDelta.x / 2f;
        inputVector = Vector2.ClampMagnitude(dragPosition / radius, 1f);
        joystickKnob.anchoredPosition = inputVector * radius;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickKnob.anchoredPosition = Vector2.zero;
    }

    public Vector2 GetInput()
    {
        return inputVector;
    }
}
