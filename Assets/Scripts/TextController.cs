using System.Linq;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textMeshPro;
    private RectTransform rectTransform;
    public float widthScaler = 1.5f;
    public float heightScaler = 1f;
    public float scalerDivisor = 100;
    [SerializeField]
    private float widthBox = 120f;
    [SerializeField]
    private float heightBox = 40f;
    private Vector2 Offset;
    private Transform OriginalParent;
    private Camera cam;
    void Start()
    {
        
    }
    public void Setup(string Text, float LifeTime, Vector2 offset, Transform transform)
    {
        cam = Camera.main;
        textMeshPro = this.GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponentInChildren<RectTransform>();
        int CharacterCount = Text.Count();
        Debug.Log(CharacterCount);
        //Debug.Log(Text);
        
        widthBox += CharacterCount * widthScaler / scalerDivisor;
        heightBox += CharacterCount * heightScaler / scalerDivisor;
        rectTransform.sizeDelta = new Vector2(widthBox, heightBox);

        textMeshPro.text = Text;
        this.GetComponent<ObjectKiller>().KillObject(LifeTime);
        //this.transform.position += Vector3.up * CharacterCount;

        OriginalParent = transform;
        Offset = offset;
    }

    void UpdatePosition()
    {
        transform.position = cam.WorldToScreenPoint(OriginalParent.position + (Vector3)Offset);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}
