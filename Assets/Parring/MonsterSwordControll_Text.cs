using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSwordControll_Text : MonoBehaviour
{
    public Animator animator; // Animator 속성 변수 생성
     public bool Texton;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Think_Attack();
    }

    // Update is called once per frame
    void Update()
    {
        // if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        // {
        //     animator.SetTrigger("Idle_");
        // }
    }

    void Think_Attack()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyAttack"))
        {
            animator.SetTrigger("Attack_");
        }
        Invoke("Think_Attack", 2);
       
    }
    public void Parring_true()
    {
        if (Texton)
        {
            Debug.Log("시작");
        }
        GameObject.Find("Sword").GetComponent<SwordControll>().CanParringTime = true;
    }
    public void Parring_false()
    {
        if (Texton)
        {
            Debug.Log("끝");
        }
        GameObject.Find("Sword").GetComponent<SwordControll>().CanParringTime = false;
        animator.SetTrigger("Idle_");
    }
}
