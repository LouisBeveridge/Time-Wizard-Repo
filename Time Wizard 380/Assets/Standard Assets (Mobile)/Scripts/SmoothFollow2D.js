
#pragma strict

var target : Transform;
var smoothTime = 0.3;
private var thisTransform : Transform;
private var velocity : Vector3;

function Start()
{
	thisTransform = this.transform;
}

function Update() 
{
	//thisTransform.position.x = Mathf.SmoothDamp( thisTransform.position.x, 
		//target.position.x, velocity.x, smoothTime);
	thisTransform.position.y = Mathf.SmoothDamp( thisTransform.position.y, 
		target.position.y, velocity.y, smoothTime);
			
	thisTransform.position.x = Mathf.SmoothDamp( thisTransform.position.x, 
		target.position.x, velocity.x, smoothTime);
		
	thisTransform.position.z = Mathf.SmoothDamp( thisTransform.position.z, 
		target.position.z, velocity.z, smoothTime);
}