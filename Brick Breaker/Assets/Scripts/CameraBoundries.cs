using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundries : MonoBehaviour
{

    public PhysicsMaterial2D pm;

    void Start() {
        GenerateCollidersAcrossScreen();
    }

    void GenerateCollidersAcrossScreen() {
        Vector2 lDCorner = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0, 0f, GetComponent<Camera>().nearClipPlane));
        Vector2 rUCorner = GetComponent<Camera>().ViewportToWorldPoint(new Vector3(1f, 1f, GetComponent<Camera>().nearClipPlane));
        Vector2[] colliderpoints;

        EdgeCollider2D upperEdge = new GameObject("upperEdge").AddComponent<EdgeCollider2D>();
        upperEdge.sharedMaterial = pm;
        colliderpoints = upperEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x+0.2f, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x-0.2f, rUCorner.y);
        upperEdge.points = colliderpoints;

        EdgeCollider2D leftEdge = new GameObject("leftEdge").AddComponent<EdgeCollider2D>();
        leftEdge.sharedMaterial = pm;
        colliderpoints = leftEdge.points;
        colliderpoints[0] = new Vector2(lDCorner.x+0.2f, lDCorner.y);
        colliderpoints[1] = new Vector2(lDCorner.x+0.2f, rUCorner.y);
        leftEdge.points = colliderpoints;

        EdgeCollider2D rightEdge = new GameObject("rightEdge").AddComponent<EdgeCollider2D>();
        rightEdge.sharedMaterial = pm;
        colliderpoints = rightEdge.points;
        colliderpoints[0] = new Vector2(rUCorner.x-0.2f, rUCorner.y);
        colliderpoints[1] = new Vector2(rUCorner.x-0.2f, lDCorner.y);
        rightEdge.points = colliderpoints;
    }
}
