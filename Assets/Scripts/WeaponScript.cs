using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public GameObject sword;
    public bool isAttack=true;
    public float CoolDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)&&isAttack)
        {
            Attack();
        }
        
    }

    private void Attack(){
        isAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown(){
        yield return new WaitForSeconds(CoolDown);
        isAttack = true;
    }
    void OnCollisionEnter(Collision col){
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("dead");
            Destroy(col.gameObject);
        }
    }
}
