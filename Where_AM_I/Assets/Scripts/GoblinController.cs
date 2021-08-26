using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GoblinController : MonoBehaviour
{
    private bool hasAniComp = false;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject player;

    public int HP = 10;

    [SerializeField]
    protected Animator anim;

    private bool isDead = false;
    private bool isWalking = false;

    // Start is called before the first frame update

    void Start()
    {
            anim.SetTrigger("idle01");
            hasAniComp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            MoveToPlayer();

            /*if (HP <= 0)
                Dead();*/

        }
        
    }

    public void MoveToPlayer()
    {
        
        
        if (hasAniComp)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 3.0f)
            {
                moveSpeed = 2f;
                isWalking = true;
                //anim.SetTrigger("walk");
                transform.LookAt(player.transform);
                transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            }

            else
            {
                isWalking = false;
                
                Attack();
            }
        }

        anim.SetBool("walk", isWalking);
    }

    public void Attack()
    {
        if(hasAniComp)
        {
            anim.SetTrigger("attack01");
            moveSpeed = 0;
        }
        HP = 0;
    }

    public void Dead()
    {
        if (hasAniComp)
        {
            isDead = true;
            anim.SetTrigger("dead");
            Destroy(this.gameObject, 2f);
        }
    }
}
