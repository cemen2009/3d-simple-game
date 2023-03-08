using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilities
{
    public static int playerDeaths = 0;

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference++;
        return "Next time you'll be at number " + countReference.ToString();
    }

    public static void RestartLevel()
    {
            SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

        Debug.Log("Player deaths: " + playerDeaths);
        string message = UpdateDeathCount(ref playerDeaths);
        Debug.Log("Player deaths: " + playerDeaths);
    }

    public static bool RestartLevel(int sceneIndex)
    {
        if (sceneIndex < 0)
        {
            throw new System.ArgumentException("Scene Index can't be negative!");
        }
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1.0f;

        return true;
    }
}