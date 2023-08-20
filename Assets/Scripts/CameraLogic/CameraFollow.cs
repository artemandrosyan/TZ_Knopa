using System;
using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float DistanceAway;
    [SerializeField]
    private float minDistance = 7f;
    [SerializeField]
    private float maxDistance = 30f;
    [SerializeField]
    private float DistanceUp = 20;
    [SerializeField]
    private float smooth = 4f;
    [SerializeField]
    private float rotateAround = 0f;
    [SerializeField]
    private float cameraHeight = 40f;
    [SerializeField]
    private float camRotateSpeed = 100f;
    [SerializeField]
    private LayerMask CamOcclusion;

    private Transform _following;                  
    private RaycastHit hit;
    private Vector3 camPosition;
    private Vector3 camMask;



    void LateUpdate()
    {
        if (_following == null)
            return;

        Vector3 targetOffset = new Vector3(_following.position.x, (_following.position.y + 2f), _following.position.z);
        Quaternion rotation = Quaternion.Euler(cameraHeight, rotateAround, 0F);
        Vector3 vectorMask = Vector3.one;
        Vector3 rotateVector = rotation * vectorMask;
       
        camPosition = targetOffset + Vector3.up * DistanceUp - rotateVector * DistanceAway;
        camMask = targetOffset + Vector3.up * DistanceUp - rotateVector * DistanceAway;

        ControlWallsVisibility(ref targetOffset);
        SmoothMove();

        transform.LookAt(_following);

        if (rotateAround > 360)
            rotateAround = 0f;
        else if (rotateAround < 0f)
            rotateAround += 360f;

        DistanceAway = Mathf.Clamp(DistanceAway+0.3f, minDistance, maxDistance);

    }
    public void Follow(GameObject following)
    {
        _following = following.transform;
        rotateAround = _following.eulerAngles.y - 45f;
    }
    private void SmoothMove()
    {
        smooth = 4f;
        transform.position = Vector3.Lerp(transform.position, camPosition, Time.deltaTime * smooth);
    }
    private void ControlWallsVisibility(ref Vector3 targetFollow)
    {
        RaycastHit wallHit = new RaycastHit();

        if (Physics.Linecast(targetFollow, camMask, out wallHit, CamOcclusion))
        {
            smooth = 10f;
            camPosition = new Vector3(wallHit.point.x + wallHit.normal.x * 0.5f, camPosition.y, wallHit.point.z + wallHit.normal.z * 0.5f);
        }
    }
}
   
