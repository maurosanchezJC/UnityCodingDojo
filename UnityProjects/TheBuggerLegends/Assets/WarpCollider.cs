using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WarpCollider : MonoBehaviour
{
    [SerializeField] private BoxCollider2D toWarp = null;
    [SerializeField] private CollisionEvent collisionEvent;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Movement player) && !player.isWarping)
        {
            player.isWarping = true;
            player.warpId = GetHashCode();
            player.transform.position = toWarp.transform.position;
            collisionEvent.Dispatch();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Movement player) && player.isWarping && player.warpId != GetHashCode())
        {
            player.isWarping = false;
        }
    }
}
