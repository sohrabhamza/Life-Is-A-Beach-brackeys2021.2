using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfootsteps : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public string currentGround;
    public AudioSource stepSource;
    public AudioClip[] selectedSounds;
    int disttoground = 3;

    // Start is called before the first frame update
    void Start()
    {
        setGroundType(GroundTypes[0]);
        stepSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Physics.OverlapSphere(transform.position, 15f, out  hit ))
        //{
        //    raycast();
        //}

        raycast();
    }


    private void raycast()
    {
        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, disttoground))
        {
            if (hit.transform.CompareTag("Wood"))
            {
                setGroundType(GroundTypes[1]);
            }
            else if (hit.transform.CompareTag("Stone"))
            {
                setGroundType(GroundTypes[2]);
            }
            else
            {
                setGroundType(GroundTypes[0]);
            }
        }
    }


    public void playSound()
    {
        stepSource.clip = selectedSounds[Random.Range(0, selectedSounds.Length)];
        stepSource.PlayOneShot(stepSource.clip);
    }
    public void setGroundType(GroundType ground)
    {
        if (currentGround != ground.name)
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
