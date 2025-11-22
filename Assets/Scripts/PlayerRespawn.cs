using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPositionX, checkPointPositionY;
    public Animator animator;
    void Start()
    {
        
    }

    public void PlayerDamaged()
    {

        animator.Play("Hit2");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
