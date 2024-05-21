using UnityEngine;
using UnityEngine.UI;

public class BeeBrain : MonoBehaviour
{
    public Text speedText;
    public float speed = 5;
    public float decisionTime = 2f;
    Vector2 TempPos;
    public AudioSource Tik;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        speedText.text = speed.ToString();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(decisionTime <= 0 || Vector2.Distance(transform.localPosition, TempPos) < 0.1f)
        {
            TempPos = new Vector2(Random.Range(-Screen.width / 2, Screen.width / 2), Random.Range(-Screen.height / 2, Screen.height / 2));
            decisionTime = 2f;
        }
        else
        {
            decisionTime -= Time.deltaTime;
        }
        //transform.localPosition = new Vector2(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2);
        float spd = 1 / (Vector2.Distance(transform.localPosition, TempPos)) * speed;
        transform.localPosition = new Vector2(Mathf.Lerp(transform.localPosition.x, TempPos.x, spd), Mathf.Lerp(transform.localPosition.y, TempPos.y, spd));
    }

    public void OnSliderValueChanged(float value)
    {
        print((int)value);
        speed = value;
        speedText.text = speed.ToString();
        audio.pitch = speed / 70;
        Tik.Play();
    }

}
