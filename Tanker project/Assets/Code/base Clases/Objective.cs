using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string objectiveTitle;
    public string objectiveDescription;
    public bool objectiveComplete;
    public bool objectiveFailed;
    public List<GameObject> objectList;


    // Start is called before the first frame update
    void Start()
    {
        objectiveComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void checkForCompletion()
    {
        // if something objectivecomplete = true
    }
}
