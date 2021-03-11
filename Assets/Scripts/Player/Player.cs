using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class Player : MonoBehaviour
{
    public GameObject bullet;
    public int maxHeatlh;
    public float speed;
    public static int currentHealth;
    public HealthSystem healthBar;
    public Text label;
    public static bool shootingTimerOn;

    private float _shootingTimer = 15f;
    private float _currentShootingTimer;

    public static bool gameOver = false;

    public  GameObject gameOverPanel;
    public ParticleSystem shootParticle;

    private GameObject _leftGun, _rightGun, _centralGun;

    void Start()
    {
        
        bullet.gameObject.GetComponent<Bullet>().advanced = false;
        
        currentHealth = maxHeatlh;
        healthBar.SetMaxHealth(maxHeatlh);
        healthBar.SetMaxHealth(currentHealth);
        _currentShootingTimer = _shootingTimer;
       
        for(int i = 0; i < this.transform.childCount; i++)
        { 
            if(i > 2 && transform.GetChild(3) != null && transform.GetChild(4) != null)
            {
               _leftGun = this.gameObject.transform.GetChild(3).gameObject;
               _rightGun = this.gameObject.transform.GetChild(4).gameObject;
            }

        }
        _centralGun = this.gameObject.transform.GetChild(2).gameObject;

        StartCoroutine(Spawn());

    }

    void Update()
    {
       

        Vector3 textPos = Camera.main.WorldToScreenPoint(this.transform.position);
        label.transform.position = textPos;
        label.transform.position = new Vector3(textPos.x, textPos.y + 60f, textPos.z);

        if (shootingTimerOn)
        {
            _currentShootingTimer -= Time.deltaTime;
            if (_currentShootingTimer <= 0)
            {
                shootingTimerOn = false;
                _currentShootingTimer = _shootingTimer;
            }
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

    }

    public void Heal(int heal)
    {
        if (currentHealth + heal > maxHeatlh)
            currentHealth = maxHeatlh;
        else
            currentHealth += heal;

        healthBar.SetHealth(currentHealth);
    }

    public void GameOver()
    {
        if(currentHealth <= 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void PickCoin()
    {
        StartCoroutine(ShowLabel());
    }


    public IEnumerator ShowLabel()
    {
           
        label.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        label.gameObject.SetActive(false);
       
    }

    public IEnumerator Spawn()
    {


        while (true)
        {
            if (_leftGun != null && _rightGun != null && bullet.GetComponent<Bullet>().advanced == true && shootingTimerOn == true)
            {
                bullet.GetComponent<Bullet>().speed = 40f;
                Instantiate(bullet, new Vector3(_centralGun.transform.position.x, _centralGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                Instantiate(bullet, new Vector3(_rightGun.transform.position.x, _rightGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                Instantiate(bullet, new Vector3(_leftGun.transform.position.x, _leftGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                yield return new WaitForSeconds(0.2f);
            }
            else if(_leftGun != null && _rightGun != null && bullet.GetComponent<Bullet>().advanced == false)
            {
                Instantiate(bullet, new Vector3(_centralGun.transform.position.x, _centralGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                Instantiate(bullet, new Vector3(_rightGun.transform.position.x, _rightGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                Instantiate(bullet, new Vector3(_leftGun.transform.position.x, _leftGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                if (bullet.gameObject.GetComponent<Bullet>().advanced == true && shootingTimerOn == true)
                {

                    shootParticle.Play();
                    Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0f, 0f, -20f));
                    Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                    Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0f, 0f, 20f));
                    yield return new WaitForSeconds(0.5f);
                }
                else
                {
                    shootParticle.Play();
                    Instantiate(bullet, new Vector3(_centralGun.transform.position.x, _centralGun.transform.position.y), Quaternion.Euler(0f, 0f, 0f));
                    yield return new WaitForSeconds(0.5f);

                }
            }
        }
    }



  

    




}
