using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text cheese;
    private int max = 2;
    public int min;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] CheeseNumber = GameObject.FindGameObjectsWithTag("Collectable");
        max = CheeseNumber.Length;
        AddScore(0);
    }

    public void AddScore(int amount)
    {
        min += amount;
        cheese.text = $" {min}/{max} ";
        if (min == max)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
