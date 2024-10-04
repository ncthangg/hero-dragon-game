using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead = 0;

    public Transform mapBounds;  // Đối tượng chứa collider để giới hạn camera
    private Vector3 minLimit, maxLimit;  // Giới hạn camera

    void Awake()
    {
        player = FindAnyObjectByType<Player>().gameObject.transform;
    }
    void Start()
    {
        // Lấy Collider của map để xác định giới hạn
        BoxCollider2D bounds = mapBounds.GetComponent<BoxCollider2D>();
        minLimit = bounds.bounds.min;
        maxLimit = bounds.bounds.max;
    }

    private void Update()
    {

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

        // Giới hạn camera
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minLimit.x, maxLimit.x);
        pos.y = Mathf.Clamp(pos.y, minLimit.y, maxLimit.y);
        transform.position = pos;

    }


}
