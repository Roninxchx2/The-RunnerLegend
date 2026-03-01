
using UnityEngine;
using UnityEngine.SceneManagement;

public class winner : MonoBehaviour
{
    public string Gameover;

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(Gameover);
    }
}