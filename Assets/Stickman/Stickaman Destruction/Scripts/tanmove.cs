using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tanmove : MonoBehaviour {
public Vector3 Distance;
    public Vector3 MovementFrequency;
    Vector3 Moveposition;
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.localPosition;
    }
    void Update()
    {		
			Moveposition.x = startPosition.x + Mathf.Tan(Time.timeSinceLevelLoad * MovementFrequency.x) * Distance.x;
		
			Moveposition.y = startPosition.y + Mathf.Tan(Time.timeSinceLevelLoad * MovementFrequency.y) * Distance.y;
			
			Moveposition.y = startPosition.y + Mathf.Tan(Time.timeSinceLevelLoad * MovementFrequency.y) * Distance.y;
			   
	
        Moveposition.z = startPosition.z + Mathf.Sin(Time.timeSinceLevelLoad * MovementFrequency.z) * Distance.z;       
        transform.localPosition = new Vector3(Moveposition.x, Moveposition.y, Moveposition.z);
		
        
    }
}
