using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCollision : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        setPlayerPos();
        DepthCollider();
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Ray ray = new Ray(player.transform.position, Vector3.down * 100);
	}

    void setPlayerPos() //sets player position //this needs to be fixed -------------------------------------------------
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //gets player
        Ray ray = new Ray(player.transform.position, Vector3.down);
        RaycastHit collide = new RaycastHit();
        
        if (Physics.Raycast(ray, out collide, 100.0f)) //calculating if collided
        {
            GameObject ground = collide.collider.gameObject; //new gameobject ground
            Vector3 colliderPos = ((BoxCollider)(collide.collider)).center; //new collider vector
            Vector3 playerPos = ground.transform.InverseTransformPoint(player.transform.position); //new vector for player
            Vector3 newPos = new Vector3(playerPos.x - colliderPos.x, playerPos.y, playerPos.z - colliderPos.z); //gets difference
            newPos = ground.transform.TransformPoint(newPos); //gets position
            player.transform.position = newPos; //set position
        }
    } //-----------------------------------------------------------------------------------------------------------------

    void DepthCollider() //sets block position
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

            Vector3 testCam = Camera.main.transform.position.normalized;
            if (Mathf.Abs(Mathf.Round(testCam.x)) == 1.0f)// if left or right
                newColliderPos = new Vector3(playerPos.x, colliderPos.y, colliderPos.z);
            else //if front or back
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);

            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos); //local space

            collider.center = newColliderPos; //set in world
        }
    }
}

