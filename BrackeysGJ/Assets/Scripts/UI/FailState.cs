using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailState : MonoBehaviour
{
    [SerializeField] GameObject catchScreen;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject timeUpScreen;
    [SerializeField] GameObject[] lifeBars;
    [SerializeField] GameObject winL;
    [SerializeField] Slider chaosMeterL;
    [SerializeField] int maxChaosL = 10;

    static GameObject win;
    static Slider chaosMeter;
    static int maxChaos = 10;

    private static FailState failInstance;
    static int chaos = 0;
    int life;

    public int hourNow = 0;

    private void Awake()
    {
        if (failInstance == null)
        {
            failInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        win = winL;
        chaosMeter = chaosMeterL;
        maxChaos = maxChaosL;

        life = lifeBars.Length;
        chaosMeter.maxValue = maxChaos;
    }

    public void loseALife()
    {
        lifeBars[lifeBars.Length - life].SetActive(false);
        life--;
        Time.timeScale = 0;
        if (life <= 0)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            catchScreen.SetActive(true);
        }
    }

    public void Fail()
    {
        Time.timeScale = 0;
        timeUpScreen.SetActive(true);
    }

    public void Continue()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        catchScreen.SetActive(false);
    }

    public void Restart()
    {
        Destroy(gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public static void IncreaseChaos()
    {
        chaos++;
        chaosMeter.value = chaos;
        if (chaos >= maxChaos)
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
