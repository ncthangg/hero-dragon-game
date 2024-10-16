using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public SaveManager saveManager;
    private int NextMap;
    void Start()
    {
        NextMap = saveManager.playerProgress.GetNextMap();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Animator playerAnimator = collision.GetComponent<Animator>();
            Player player = collision.GetComponent<Player>();
            if (playerAnimator != null)
            {
                player.StopMovement();
                Debug.Log("player animator is not null");
                playerAnimator.SetTrigger("win");
            }

            saveManager.CompletedMap(NextMap);

            StartCoroutine(WaitAndLoadNextLevel(3f));
        }
    }

    // Coroutine để đợi ... giây trước khi gọi NextLv()
    private IEnumerator WaitAndLoadNextLevel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NextLv();
    }

    public void NextLv()
    {
        Debug.Log("start");
        SceneManager.LoadScene(NextMap);
    }
}
