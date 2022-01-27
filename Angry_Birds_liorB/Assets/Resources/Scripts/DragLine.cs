using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lineRenderer;
    private Bird _bird;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
   
    void Update()
    {
        if (_bird == null)
        {
            _bird = FindObjectOfType<Bird>();
            if (_bird != null)
            {
                _lineRenderer.SetPosition(0, _bird.transform.position);
            }
        }

        if (_bird == null || _bird.IsDragging == false)
        {
            _lineRenderer.enabled = false;
            return;
        }

        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(1, _bird.transform.position);
    }
}