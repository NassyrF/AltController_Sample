using UnityEngine;
using Unity.Cinemachine;

public class cameraValue : MonoBehaviour
{

    private CinemachineVirtualCamera vcam;

    void Start(){
        vcam=this.GetComponent<CinemachineVirtualCamera>();
    }

    public void myCamNumber(int priority_num){
        vcam.Priority.Value=priority_num;
    }
}
