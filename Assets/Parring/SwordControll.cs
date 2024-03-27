using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordControll : MonoBehaviour
{
    public Animator animator; // Animator 속성 변수 생성
    public bool CanParringTime;
    public Text parring_text;
    int parring_count;

    // Start is called before the first frame update
    void Start()
    {
        parring_count=0;
        Application.targetFrameRate = 120;
        animator = GetComponent<Animator>();
        CanParringTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack_");
        }
        if (Input.GetKey(KeyCode.X) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("Attack_");
        }
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            animator.SetTrigger("Idle_");
        }
    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "CanParring" && CanParringTime && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            print("패링 성공!");
            parring_count +=1;
            parring_text.text = parring_count.ToString();
            // Time.timeScale = 0.5f;
            // Invoke("TimeSet", 0.5f);
        }
    }
    // void TimeSet()
    // {
    //     Time.timeScale = 1f;
    // }
}

