using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        transform.position = new Vector3(Player.position.x, transform.position.y, transform.position.z);
    }
}