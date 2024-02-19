using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera; // Make sure to assign whatever camera used in the scene
    public float moveSpeed = 5f; // Adjust as needed

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // This checks if the left mouse button was pressed. If so calls upon the movePlayer function
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Sends out a ray cast to see if a cube was hit.
            Vector3 targetPosition = hit.collider.gameObject.transform.position;
            // Adjusts the sprite to make it in the middle of the selected cube IMPORTANT THAT SPRITE IS 1 HEIGHT
            targetPosition.y += 1.2f + (transform.localScale.y / 2);
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition) //This is a coroutine that allows the sprite to smoothly move.
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}

