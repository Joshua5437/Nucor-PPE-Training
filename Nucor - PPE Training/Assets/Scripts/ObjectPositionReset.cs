using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPositionReset : MonoBehaviour
{
    public GameObject AnimatedObject;
    public float AnimationEndTime = 0;
    private Vector3 movement;
    private Vector3 ObjectPosition, ObjectRotation;

    private void Start()
    {
        ObjectPosition = AnimatedObject.transform.localPosition;
        ObjectRotation = AnimatedObject.transform.localEulerAngles;

        StartCoroutine(RestartAnimation());
    }

    private IEnumerator RestartAnimation()
    {
        yield return new WaitForSeconds(AnimationEndTime);
        PositionReset();
    }

    public void PositionReset()
    {
        AnimatedObject.GetComponent<Rigidbody>().velocity = movement;
        AnimatedObject.transform.localPosition = ObjectPosition;
        AnimatedObject.transform.localRotation = Quaternion.Euler(ObjectRotation.x, ObjectRotation.y, ObjectRotation.z);

        StartCoroutine(RestartAnimation());
    }
}
