using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/HandleAttack")]
public class HandleAttack : MonoBehaviour
{
   public int takeDamage = 5;
    public bool isHande = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy")&&isHande==true)
        {
            IDamageble obj = other.GetComponent<IDamageble>();
            if(obj != null )
            {
                obj.TakeDamage(takeDamage);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
           StopCoroutine(FallHandle());
        }
    }
    public void SetHandle()
    {
        isHande = true;
        StartCoroutine(FallHandle());
    }
    IEnumerator FallHandle()
    {
        yield return new WaitForSeconds(1f);
        isHande=false;
    }
}
