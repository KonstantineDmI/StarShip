using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    public GameObject menuPanel;

    [SerializeField]
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = menuPanel.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        StartCoroutine(PauseGame());
        _animator.SetBool("IsVisible", true);
       
    }

    public void Resume()
    {
        StartCoroutine(UnpauseGame());
        _animator.SetBool("IsVisible", false);
        


    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GameOver()
    {
        AppStart start = new AppStart();
        start.DataAdding();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator PauseGame()
    {
        menuPanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        
        

    }

    IEnumerator UnpauseGame()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(1f);
        menuPanel.SetActive(false);
    }

}
