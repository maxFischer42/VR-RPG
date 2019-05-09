using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float cooldown = 5f;
    public GameObject fireball;
    bool oncooldown = false;
    public float speed = 3f;
    public Transform startposition;
    public Transform player;
    public AudioSource aud;
    public AudioClip clip;
    public Animator anim;
    public RuntimeAnimatorController attackAnimation;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spitFire(true));
    }

    // Update is called once per frame
    void Update()
    {
        if(!oncooldown)
        {
            StartCoroutine(spitFire(true));
        }
    }

    public IEnumerator spitFire(bool doFire)
    {
        anim.runtimeAnimatorController = attackAnimation;
        oncooldown = true;
        yield return new WaitForSeconds(2f);
        if (doFire) {
            aud.PlayOneShot(clip);
            GameObject ball = (GameObject)Instantiate(fireball, startposition);
            ball.transform.parent = null;
            Vector3 velocity = player.transform.position - startposition.position;
            velocity.Normalize();
            ball.GetComponent<Rigidbody>().velocity = velocity * speed;
            Destroy(ball, 10f);
        }
        yield return new WaitForSeconds(cooldown);
        anim.runtimeAnimatorController = null;
        oncooldown = false;
    }
}
