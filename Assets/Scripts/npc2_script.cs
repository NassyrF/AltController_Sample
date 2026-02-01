using UnityEngine;

public class npc2_script : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim=this.GetComponent<Animator>();
        if(this.transform.parent.gameObject.name=="NPC2"){
            anim.SetTrigger("Sit");
        }
        else{
            anim.SetTrigger("Crouch");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                         Camera.main.transform.rotation * Vector3.up);
    }
}
