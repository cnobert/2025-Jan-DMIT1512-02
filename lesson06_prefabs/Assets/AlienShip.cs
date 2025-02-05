using UnityEngine;

public class AlienShip : MonoBehaviour
{
    public GameObject projectilePrefab;
    void Start()
    {
        GameObject projectile = Instantiate(projectilePrefab); //creates a prefab object, and brings it into the scene
        //projectile.transform.position = this.transform.position;
        //in-class exercise:
        //add to the above code so that the projectile is placed directly below the AlienShip
        float myHeight = GetComponent<Renderer>().bounds.size.y;
        float projectileHeight = projectile.GetComponent<Renderer>().bounds.size.y;
        Vector3 newPosition = transform.position - new Vector3(0, (myHeight / 2) + (projectileHeight / 2), 0);
        projectile.transform.position = newPosition;

        //in-class exercise: set the direction and speed of the projectile from here
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
