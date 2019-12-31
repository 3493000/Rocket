using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetFlowLight: MonoBehaviour {
    private float widthRate = 1;
    private float heightRate = 1;
    private float xOffsetRate = 0;
    private float yOffsetRate = 0;
   // public Shader shader;
    public Color color = Color.yellow;
    public float power = 0.55f;
    public float speed = 5;
    public float largeWidth = 0.003f;
    public float littleWidth = 0.0003f;
    public float length = 0.1f;
    public float skewRadio = 0.2f;//倾斜
    public float moveTime = 0;
    public float stepSpeed;
    float endMoveTime = 0;
    private MaskableGraphic maskableGraphic;
    private bool isStart = false;
    Image image;
    Material imageMat = null;
    void Awake()
    {

        
    }
    private void OnEnable()
    {
        maskableGraphic = GetComponent<MaskableGraphic>();
        if (maskableGraphic)
        {
            image = maskableGraphic as Image;
            if (image)
            {
                imageMat = new Material(Shader.Find("Custom/UI/Flowlight"));
                widthRate = image.sprite.textureRect.width * 1.0f / image.sprite.texture.width;
                heightRate = image.sprite.textureRect.height * 1.0f / image.sprite.texture.height;
                xOffsetRate = (image.sprite.textureRect.xMin) * 1.0f / image.sprite.texture.width;
                yOffsetRate = (image.sprite.textureRect.yMin) * 1.0f / image.sprite.texture.height;
            }
        }
        image.material = imageMat;
        isStart = true;
        moveTime = 0;
    }
    //public void OnWaitAnim(float time)
    //{
    //    // Debug.Log(time);
    //    StopCoroutine("SlowLight");
    //    endMoveTime = time;
    //    StartCoroutine("SlowLight");
    //}
    //IEnumerator SlowLight()
    //{
    //    if (image)
    //    {
    //        image.material = imageMat;
    //    }
    //    moveTime = 0;
    //    while (moveTime < endMoveTime)
    //    {
    //        moveTime += Time.deltaTime;
    //        SetShader();
    //        // Debug.Log(moveTime + ":" + endMoveTime);
    //        yield return null;
    //    }
    //    if (image)
    //    {
    //        image.material = null;
    //    }
    //}
    void OnDisable()
    {
        if (image)
        {
            image.material = null;
        }
        isStart = false;
    }
    void Start()
    {
          
    }
    void Update()
    {
        if (isStart)
        {
            moveTime += stepSpeed * Time.deltaTime;

            //if (moveTime > 1f)
            //{
            //    moveTime = 0f;
            //}
            SetShader();
        }
        
    }
    public void SetShader()
    {
        skewRadio = Mathf.Clamp(skewRadio, 0, 1);
        length = Mathf.Clamp(length, 0, 0.5f);
        imageMat.SetColor("_FlowlightColor", color);
        imageMat.SetFloat("_Power", power);
        imageMat.SetFloat("_MoveSpeed", speed);
        imageMat.SetFloat("_LargeWidth", largeWidth);
        imageMat.SetFloat("_LittleWidth", littleWidth);
        imageMat.SetFloat("_SkewRadio", skewRadio);
        imageMat.SetFloat("_Lengthlitandlar", length);
        imageMat.SetFloat("_MoveTime", moveTime);

        imageMat.SetFloat("_WidthRate", widthRate);
        imageMat.SetFloat("_HeightRate", heightRate);
        imageMat.SetFloat("_XOffset", xOffsetRate);
        imageMat.SetFloat("_YOffset", yOffsetRate);
    }

}

