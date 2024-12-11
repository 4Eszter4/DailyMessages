using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageAnimator : MonoBehaviour
{
    public Transform targetPosition; // Desired position for the message
    public float animationDuration = 2f; // Duration of the animation in seconds
    public Vector3 initialScale = Vector3.zero; // Starting scale (invisible)
    public Vector3 finalScale = Vector3.one; // Final scale (normal size)
    private float elapsedTime = 0f; // Tracks animation time
    private Vector3 startPosition; // Starting position of the message
    private Vector3 startPosition2;
    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the message
        startPosition = transform.position;
        // Set the message to the initial scale
        transform.localScale = initialScale;
        Animator();
    }

    public void Animator()
    {
        // Set the message to the initial scale
        transform.localScale = Vector3.zero;
        elapsedTime = 0f;
        // Start the animation coroutine
        StartCoroutine(AnimateMessage());
    }

    System.Collections.IEnumerator AnimateMessage()
    {
        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (0 to 1)
            float t = elapsedTime / animationDuration;

            // Animate position (smoothly interpolating between start and target)
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);

            // Animate scale (smoothly growing from initial to final scale)
            transform.localScale = Vector3.Lerp(initialScale, finalScale, t);

            //alpha
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            Color color = text.color;
            color.a = t; // Gradually increase alpha (0 to 1)
            text.color = color;

            yield return null; // Wait for the next frame
        }

        // Ensure the final position and scale are set
        transform.position = targetPosition.position;
        transform.localScale = finalScale;
    }
}
