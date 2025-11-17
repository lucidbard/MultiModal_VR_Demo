using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    void OnCollisionEnter(Collision collision)
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(audio.clip);
    }

    // Update is called once per frame
    void Update() { }
}
