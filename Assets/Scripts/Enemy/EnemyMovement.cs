using UnityEngine;
using System.Collections;
using VRTK;

public class EnemyMovement : MonoBehaviour
{
    public GameObject mainCamera;
    Transform player;
    Transform camera_rig;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
      //  VRTK.VRTK_SDKManager.instance.AddBehaviourToToggleOnLoadedSetupChange(this);
        mainCamera = VRTK.VRTK_DeviceFinder.PlayAreaTransform().gameObject;
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        camera_rig = GameObject.FindGameObjectWithTag("CameraRig").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if(enemyHealth.CurrentHealth > 0 && playerHealth.CurrentHealth > 0)
        {
            nav.SetDestination (camera_rig.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
