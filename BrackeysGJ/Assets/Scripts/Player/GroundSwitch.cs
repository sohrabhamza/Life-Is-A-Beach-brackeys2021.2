using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSwitch : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public string currentGround;
    public AudioSource stepSource;
    public AudioClip[] selectedSounds;

    // Start is called before the first frame update
    void Start()
    {
        setGroundType(GroundTypes[0]);
        stepSource = GetComponent<AudioSource>();
        
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
            Debug.Log("Wood");
        }
        else if(hit.transform.tag == "Stone")
        {
            setGroundType(GroundTypes[2]);
            Debug.Log("Stone");
        }
        else
        {
            setGroundType(GroundTypes[0]);
        }
        Debug.Log("ColliderHit");
    }

    

    public void playSound()
    {
        stepSource.clip = selectedSounds[Random.Range(0, selectedSounds.Length)];
        stepSource.PlayOneShot(stepSource.clip);
    }
    public void setGroundType(GroundType ground)
    {
        if(currentGround != ground.name)
        {
            selectedSounds = ground.footstepSound;
            currentGround = ground.name;
        }

        
    }

    [System.Serializable]
    public class GroundType
    {
        public string name;
        public AudioClip[] footstepSound;
    }
}
