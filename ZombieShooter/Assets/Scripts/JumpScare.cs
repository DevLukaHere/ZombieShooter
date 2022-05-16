using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource Scream;
    public GameObject Zombie;
    void OnTriggerEnter()
    {
        Scream.Play();
        Zombie.SetActive(true);
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(2.0f);
        Zombie.SetActive(false);
    }
}
