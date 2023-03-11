using TMPro;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.5f;

    [SerializeField]
    private Lesson12 lesson12;

    [SerializeField]
    private TMP_Text distance;

    [SerializeField]
    private Camera cam;

    private float X;
    private float Y;
    private bool isPause = true;

    void Update()
    {
        if (distance != null)
            distance.transform.rotation = Quaternion.LookRotation(-cam.transform.position + distance.transform.position);

        if (Input.GetMouseButton(0) && !isPause)
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);

            if (lesson12 != null && (Input.GetAxis("Mouse Y") != 0 || Input.GetAxis("Mouse X") != 0))
                lesson12.CompletedLesson();
        }
    }

    public void Pause(bool pause)
    {
        isPause = pause;
        if (pause)
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}