
using UnityEngine;

public class PathListener : MonoBehaviour
{
    private const string message = "The next path is to the ";

    private string Message => message + WarpListener.instance.GetNextPath();
    
    public void ShowLog()
    {
        if (WarpListener.instance.Arrived)
        {
            Debug.Log("YOU ARRIVED! CONGRATS!!! The secret word is QUE PICARDIA");
            return;
        }
        
        
        Debug.Log(Message);
    }
}
