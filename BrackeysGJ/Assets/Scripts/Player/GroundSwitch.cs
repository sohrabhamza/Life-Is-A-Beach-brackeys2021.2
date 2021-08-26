using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSwitch : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public string currentGround;


    // Start is called before the first frame update
    void Start()
    {
        setGroundType(GroundTypes[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Wood")
        {
            setGroundType(GroundTypes[1]);
        }
        else if(hit.transform.tag == "Stone")
        {
            setGroundType(GroundTypes[2]);
        }
        else
        {
            setGroundType(GroundTypes[0]);
        }
    }

    public void setGroundType(GroundType ground)
    {


        currentGround = ground.name;
    }

    [System.Serializable]
    public class GroundType
    {
        public string name;
        public AudioClip[] footstepSound;

        public float walkSpeed;

    }
}
