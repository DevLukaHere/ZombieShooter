using UnityEngine;
using System.Collections;

public class EasyAI : MonoBehaviour
{
    public CharacterController characterControler;
    private Transform player;
    private Transform enemy;

    public float rotationSpeed = 4.0f;
    public float moveSpeed = 5.0f;
    public float range = 30.0f;

    public float jumpHeight = 0f;
    public float whenStop = 0f;

    void Start()
    {
        characterControler = GetComponent<CharacterController>();
        enemy = transform;
        GameObject go = GameObject.FindWithTag("Player");
        player = go.transform;
    }

    void Update()
    {
        float range = Vector3.Distance(enemy.position, player.position);
        if (range < this.range && range > whenStop)
        {
            Vector3 graczPoz = new Vector3(player.position.x, player.position.y, player.position.z);
            enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(graczPoz - enemy.position), moveSpeed * Time.deltaTime);

            if (!characterControler.isGrounded)
            {
                jumpHeight += Physics.gravity.y * Time.deltaTime;
            }

            Vector3 move = new Vector3(enemy.forward.x, jumpHeight, enemy.forward.z);
            characterControler.Move(move * moveSpeed * Time.deltaTime);
        }


    }
}