using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Vector3 GetDirection()
    {
        Vector3 playerPos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector3 mousePos = Input.mousePosition;
        Vector3 direction = mousePos - playerPos;
        return new Vector3(direction.x, 0, direction.y);
    }

}
