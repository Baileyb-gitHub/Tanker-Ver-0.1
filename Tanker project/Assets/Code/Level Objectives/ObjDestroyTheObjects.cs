using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyTheObjects : Objective
{
    public List<GameObject> thingsToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void checkForCompletion()
    {
        bool done = true;

        foreach(GameObject thing in thingsToDestroy)
        {
            if (thing != null)
            {
                done = false;
            }
        } 

        if(done == true)
        {
            objectiveComplete = true;
        }


    }
}
