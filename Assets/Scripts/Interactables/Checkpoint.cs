using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public SpriteRenderer mySpriteRenderer;

    public Sprite checkpointOn, checkpointOff;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.isTrigger)
        {
            Debug.Log("Checkpoint on set");

            CheckpointController.instance.DeactivateCheckpoints();
            mySpriteRenderer.sprite = checkpointOn;

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }


    public void ResetCheckpoint()
    {
        mySpriteRenderer.sprite = checkpointOff;
    }
}
