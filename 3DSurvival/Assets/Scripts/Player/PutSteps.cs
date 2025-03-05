using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutSteps : MonoBehaviour
{
    public AudioClip[] footstepClip;
    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    public float footStepThresshold;
    public float footstepRate;
    private float footStepTime;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(_rigidbody.velocity.y)<0.1f)
        {
            if(_rigidbody.velocity.magnitude>footStepThresshold)
            {
                if(Time.time - footStepTime> footstepRate)
                {
                    footStepTime = Time.time;
                    audioSource.PlayOneShot(footstepClip[Random.Range(0, footstepClip.Length)]);
                }
            }
        }
    }
}
