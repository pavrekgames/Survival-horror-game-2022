using UnityEngine;
using UnityEngine.UI;

public class TaskPoint : MonoBehaviour {

    public Sprite pointIcon;
    public Image pointImage;

    public Vector2 PointPosition
    {
        get { return new Vector2(transform.position.x, transform.position.z); }
    }


}
