using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Movement player;
    [SerializeField] private Vector2 direction;

    private bool pressed = false;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    private void Update()
    {
        if (!pressed) return;
        
        player.Move(direction);
    }
}
