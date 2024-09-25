using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVMaskFollow : MonoBehaviour
{
    public Transform player;
    private RectTransform maskRectTransform;
    private Camera mainCamera;

    void Start()
    {
        maskRectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (player != null && mainCamera != null)
        {
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(player.position);

            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(maskRectTransform.parent.GetComponent<RectTransform>(), screenPosition, mainCamera, out localPoint);

            maskRectTransform.anchoredPosition = localPoint;
        }
    }
}