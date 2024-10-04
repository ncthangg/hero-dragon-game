using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private GameObject fireEffect;
    [SerializeField] private int damage;       // Số lượng máu trừ khi va chạm
    [SerializeField] private float fireRun = 5f;  // Thời gian phun lửa
    [SerializeField] private float fireDelay = 3f;  // Thời gian chờ giữa mỗi lần phun lửa
    private bool isFiring = false;

    private void Start()
    {
        // Ẩn lửa khi khởi động
        fireEffect.SetActive(false);
        StartCoroutine(FireRoutine());
    }

    // Coroutine điều khiển việc phun lửa theo chu kỳ
    private IEnumerator FireRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireDelay);
            // Bắt đầu phun lửa
            fireEffect.SetActive(true);
            isFiring = true;

            yield return new WaitForSeconds(fireRun);
            // Dừng phun lửa
            fireEffect.SetActive(false);
            isFiring = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("va cham");
        if (isFiring && collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDame(damage);
            Debug.Log("nhan dame");
        }
    }
}