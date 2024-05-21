using UnityEngine;

public class eyeBrain : MonoBehaviour
{
    public bool msc;
    AudioSource aud;
    public Transform Bee;
    public float distance;
    public float smoothTime = 1;
    float X;
    float Y;
    public float eyeWidth;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    void Update()
    {
        Vector2 centered = new Vector2(Bee.position.x - transform.position.x, Bee.position.y - transform.position.y);
        X = (centered.x / Screen.width) * (distance + 1) * eyeWidth;
        Y = (centered.y / Screen.width) * (distance + 1) * eyeWidth;
        X = Mathf.Clamp(X, -eyeWidth, eyeWidth);
        Y = Mathf.Clamp(Y, -eyeWidth, eyeWidth);
        transform.localPosition = new Vector2(Mathf.Lerp(transform.localPosition.x, X, smoothTime * Time.deltaTime), Mathf.Lerp(transform.localPosition.y, Y, smoothTime * Time.deltaTime));
        if (msc)
        {
            float tmpX = transform.localPosition.x - X;
            float tmpY = transform.localPosition.y - Y;
            if(tmpX < 0)
            {
                tmpX = -tmpX;
            }
            if (tmpY < 0)
            {
                tmpY = -tmpY;
            }
            aud.volume = Mathf.Max(tmpX, tmpY) / 300;
        }
    }
}
