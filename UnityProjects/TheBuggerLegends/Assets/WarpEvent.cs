using UnityEngine;

public class WarpEvent : CollisionEvent
{
    [SerializeField] private GamePath.Path path;
    public override void Dispatch()
    {
        WarpListener.instance.Listen(path);
    }
}
