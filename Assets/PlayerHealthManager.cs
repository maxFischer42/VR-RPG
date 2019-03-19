using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;

    public Scrollbar healthBar;
    private float healTimer;
    public Image fadeOutImage;
    private float fadeOutTimer;

    private bool isDead = false;

    public string deathScene;

    public void Update()
    {
        healthBar.size = (float)currentHealth / (float)maxHealth;
        if (currentHealth <= 0)
        {
            KillPlayer();
        }
        if (!isDead)
        {
            healTimer += Time.deltaTime;
            if (healTimer > 10f && currentHealth < maxHealth)
            {
                currentHealth++;
            }
            
        }
        else if(isDead)
        {
            fadeOutTimer += 0.1f;
            Color newColor = fadeOutImage.color;
            newColor.a = fadeOutTimer;
            fadeOutImage.color = newColor;
            if(fadeOutTimer >= 1)
            {
                SceneManager.LoadScene(deathScene);
            }
        }

        //remove this when not debugging
        if(OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        {
            DoDamage(5);
        }
    }

    public void DoDamage(int damage)
    {
        healTimer = 0f;
        currentHealth -= damage;
    }

    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void KillPlayer()
    {
        isDead = true;
        healthBar.handleRect.GetComponent<Image>().enabled = false;
    }

    
}
