using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InputService : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    [SerializeField]
    private Image joystickBg;
    [SerializeField]
    private Image joystick;
    private Vector2 inputVector;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBg.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x /= joystickBg.rectTransform.sizeDelta.x;
            pos.y /= joystickBg.rectTransform.sizeDelta.y;
        }
        inputVector = new Vector2(pos.x * 2, pos.y * 2);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBg.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBg.rectTransform.sizeDelta.y / 2));
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxisRaw(HORIZONTAL);
    }
    public float Vertical()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxisRaw(VERTICAL);
    }

    public Vector2 GetAxis()
    {
        return new Vector2(Horizontal(), Vertical());
    }
}