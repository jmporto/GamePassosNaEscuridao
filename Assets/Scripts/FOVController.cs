using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVController : MonoBehaviour
{
    public Transform player;
    public RectTransform maskTransform;

    void Update()
    {
        Vector3 playerPositionOnScreen = Camera.main.WorldToScreenPoint(player.position);

        maskTransform.position = playerPositionOnScreen;
    }
}