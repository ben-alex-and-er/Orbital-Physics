using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private Lesson12 lesson12;

    private float X;
    private float Y;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);

            if (lesson12 != null && (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0))
                lesson12.CompletedLesson();
        }
    }


}