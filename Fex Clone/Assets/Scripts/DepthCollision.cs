using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCollision : MonoBehaviour {

    private int distance = 1;

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
        fallCheck();
    }

    public void destroyPrize() //once the prize has been touched causes it to do something (currently dissapear)
    {
        GameObject prize = GameObject.FindGameObjectWithTag("Prize");
        GameObject[] assets = GameObject.FindGameObjectsWithTag("PrizeAsset");
        Destroy(prize);
        for(int i = 0; i < assets.Length; i++)
        {
            Destroy(assets[i]);
        }
    }

    public void prizeCheck(GameObject player, bool leftright) ////check to see if the player is touching the prize
    {
        GameObject prize = GameObject.FindGameObjectWithTag("Prize"); //gets prize object
        if (prize != null)
        {
            Vector3 prizePos = prize.transform.position;
            Vector3 playerPos = player.transform.position;

            if (leftright) //if looking from left or right view, eliminate the x component
            {
                if ((playerPos.z > (prizePos.z - distance)) && (playerPos.z < (prizePos.z + distance)) && (playerPos.y > (prizePos.y - distance)) && (playerPos.y < (prizePos.y + distance)))
                {
                    destroyPrize();
                }
            }

            else //if looking from forward or backward, eliminate the z component
            {
                if ((playerPos.x > (prizePos.x - distance)) && (playerPos.x < (prizePos.x + distance)) && (playerPos.y > (prizePos.y - distance)) && (playerPos.y < (prizePos.y + distance)))
                {
                    destroyPrize();
                }
            }
        }
    }

    public void fallCheck() //if the player falls to far, resets them
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.position.y < -10)
        {
            Vector3 newPos = new Vector3(0, 2, -2.5f);
            player.transform.position = newPos;
        }
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
                prizeCheck(player, true);
            }
            else //if looking from front or back
            {
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);
                prizeCheck(player, false);
            }

            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos); //local space

            collider.center = newColliderPos; //set in world
        }
    }
}

