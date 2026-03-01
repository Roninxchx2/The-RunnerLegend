using UnityEngine;
using UnityEngine.SceneManagement;

public class winnerr : MonoBehaviour
{
    public string Winerrr;

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(Winerrr);
    }
}