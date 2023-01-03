using UnityEngine;
using System.Collections;

public class FixedJointScript : MonoBehaviour
{
    public float TimeToWait = 0;  // Time to wait before the "JointedObject" is attached to the "AnimatedObject".
    public float DisconnectTime = 0;
    public float AnimationEndTime = 0;
    public GameObject JointedObject;
    public GameObject AnimatedObject;
    private Vector3 AnimatedObjectPosition, AnimatedObjectRotation, JointedObjectPosition, JointedObjectRotation;

    private void Start()
    {
        // Collects the starting position and rotation of the object attached to the animated object.
        JointedObjectPosition = JointedObject.transform.position;
        JointedObjectRotation = JointedObject.transform.eulerAngles;

        // Collects the starting position and rotation of the animated object.
        AnimatedObjectPosition = AnimatedObject.transform.localPosition;
        AnimatedObjectRotation = AnimatedObject.transform.localEulerAngles;

        StartCoroutine(CreateFixedJoint());
        StartCoroutine(RestartAnimation());
        StartCoroutine(Wait2Disconnect());
    }

    private IEnumerator CreateFixedJoint()
    {
        AnimatedObject.GetComponent<Animator>().Play("Rigged Worker|Rigged WorkerAction");
        yield return new WaitForSeconds(TimeToWait); 
        JointedObject.GetComponent<FixedJoint>().connectedBody = AnimatedObject.GetComponent<Rigidbody>();
    }
    private IEnumerator Wait2Disconnect()
    {
        yield return new WaitForSeconds(DisconnectTime); 
        DisconnectFixedJoint();
    }

    private IEnumerator RestartAnimation()
    {
        yield return new WaitForSeconds(AnimationEndTime);
        AnimatedObjectReset();
    }

    public void DisconnectFixedJoint() // Disconnects the "Jointed Object" from the "Animated Object".
    {
        JointedObject.GetComponent<FixedJoint>().connectedBody = null;
        JointedObjectReset();
    }

    public void JointedObjectReset()
    {
        // Resets "JointedObject" to the original position and rotation. 
        JointedObject.transform.position = JointedObjectPosition;
        JointedObject.transform.rotation = Quaternion.Euler(JointedObjectRotation.x, JointedObjectRotation.y, JointedObjectRotation.z);
    }

    public void AnimatedObjectReset() 
    {
        // Resets "AnimatedObject" to the original position and rotation.
        AnimatedObject.transform.localPosition = AnimatedObjectPosition;
        AnimatedObject.transform.localRotation = Quaternion.Euler(AnimatedObjectRotation.x, AnimatedObjectRotation.y, AnimatedObjectRotation.z);

        StartCoroutine(CreateFixedJoint()); // Starts coroutines again. (Loops)
        StartCoroutine(Wait2Disconnect());
    }
}