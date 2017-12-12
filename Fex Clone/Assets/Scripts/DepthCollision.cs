using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCollision : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Ray ray = new Ray(player.transform.position, Vector3.down * 100);
        setPlayerPos();
        DepthCollider();
    }

    public void setPlayerPos() //move player if the block moves from underneath him
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Ray ray = new Ray(player.transform.position, Vector3.down);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            GameObject platform = hit.collider.gameObject;
            Vector3 colliderPos = ((BoxCollider)(hit.collider)).center;
            Vector3 playerPos = platform.transform.InverseTransformPoint(player.transform.position);
            Vector3 newPos = new Vector3(playerPos.x - colliderPos.x, playerPos.y, playerPos.z - colliderPos.z);
            newPos = platform.transform.TransformPoint(newPos);

            player.transform.position = newPos;
        }
    }

    void DepthCollider()
    {
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform; //get player game object
        GameObject[] groundObjects = GameObject.FindGameObjectsWithTag("Ground"); //gets all ground type objects

        for (int i = 0; i < groundObjects.Length; i++) //goes through the list of ground objects
        {
            GameObject ground = groundObjects[i]; //setting ground object to current platform
            BoxCollider collider = ground.GetComponentInChildren<BoxCollider>(); //new collider object
            collider.center = Vector3.zero; //default position

            Vector3 colliderPos = collider.transform.TransformPoint(collider.center); //colliderPos centered on collider

            Vector3 playerPos = playerTransform.position; //new vector3 on player

            Vector3 newColliderPos;

            //move platform collider depending on what side the camera is facing 
            GameObject player = GameObject.FindGameObjectWithTag("Player"); //gets player
            float rotation = Mathf.Rad2Deg * player.transform.rotation.y; //get rotation to determine what angle we are looking at
            if (Mathf.Abs(Mathf.Round(rotation)) == 41) //if looking from left or right
            {
                newColliderPos = new Vector3(playerPos.x, colliderPos.y, colliderPos.z);
            }
            else //if looking from front or back
            {
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);
            }

            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos); //local space

            collider.center = newColliderPos; //set in world
        }
    }
}

