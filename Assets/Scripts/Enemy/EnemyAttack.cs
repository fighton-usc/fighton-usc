using UnityEngine;
using System.Collections;
using VRTK;

public class EnemyAttack : MonoBehaviour
{
    public GameObject mainCamera;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
   


    void Awake()
    {
        
        if (mainCamera == null)
        {
            // VRTK.VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
            mainCamera = VRTK.VRTK_DeviceFinder.PlayAreaTransform().gameObject;
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
            enemyHealth = GetComponent<EnemyHealth>();
            anim = GetComponent<Animator>();
        }
        
    }


    void OnTriggerEnter (Collider other)
    {print(other.gameObject+"hey");
        if(other.gameObject == mainCamera.gameObject)
        {
            print("hi entering trigger");
        
            playerInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == mainCamera)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.CurrentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth.CurrentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.CurrentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
