using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class openNotif : MonoBehaviour
{
    public GameObject dstr;
    public string cnvs;
    public GameObject notfcs;
    public bool OnOff;
    bool inMotion;
    PostProcessVolume vol;
    GameObject canvas;
    DepthOfField depth;
    public void OpnCls()
    {
        if (!inMotion)
        {
            OnOff = !OnOff;
            inMotion = true;
            if (OnOff)
            {
                Instantiate(notfcs, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity, canvas.transform);
            }
        }
    }
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag(cnvs);
        vol = GameObject.FindGameObjectWithTag("PostProcessing").GetComponent<PostProcessVolume>();
        vol.profile.TryGetSettings(out depth);
    }

    // Update is called once per frame
    void Update()
    {
        if (inMotion)
        {
            if (OnOff)
            {
                depth.focusDistance.value = Mathf.Lerp(depth.focusDistance.value, 0.1f, 0.1f);
                if(depth.focusDistance.value <= 0.3f)
                {
                    depth.focusDistance.value = 0.1f;
                    inMotion = false;
                    OnOff = !OnOff;
                }
            }
            else
            {
                depth.focusDistance.value = Mathf.Lerp(depth.focusDistance.value, 6, 0.5f);
                if (depth.focusDistance.value >= 4)
                {
                    depth.focusDistance.value = 6;
                    inMotion = false;
                    Destroy(dstr.gameObject);
                }
            }
        }
    }
}
