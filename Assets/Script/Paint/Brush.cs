using UnityEngine;

public class Brush : MonoBehaviour
{
    public Camera paintCamera;
    public GameObject clay;
    public Material cylinderMaterial;
    public Texture2D brushTexture;
    public Color brushColor = Color.red;
    public float brushSize = 0.1f;

    private RenderTexture renderTexture;
    private SkinnedMeshRenderer skinnedMR;

    private void Start()
    {
        //paintCamera = Camera.main;

        skinnedMR = clay.GetComponent<SkinnedMeshRenderer>();

        renderTexture = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGB32);
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = null;
        renderTexture.Create();

        paintCamera.clearFlags = CameraClearFlags.SolidColor;
        paintCamera.backgroundColor = new Color(0, 0, 0, 0);
        paintCamera.depth = 1;
        paintCamera.targetTexture = renderTexture;
        paintCamera.aspect = 1.0f;

        Material material = skinnedMR.material;
        //material.SetTexture("_BaseMap", renderTexture);
    }

    private void Update()
    {

    }

    public void Draw()
    {
        RaycastHit hit;
        int layerMask = 1 << LayerMask.NameToLayer("ClayMask");
        if (Physics.Raycast(new Ray(transform.position, transform.forward), out hit, Mathf.Infinity, layerMask))
        {
            MeshCollider meshCollider = hit.collider.GetComponent<MeshCollider>();
            if(meshCollider != null)
            {
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= renderTexture.width;
                pixelUV.y *= renderTexture.height;

                //Debug.Log("Drawing on pos : (" + pixelUV.x + ", " + pixelUV.y + ")!");

                Vector3 worldPos = hit.point;
                paintCamera.transform.position = worldPos - transform.forward * 0.3f;
                paintCamera.transform.LookAt(worldPos);

                DrawBrush((int)pixelUV.x, (int)pixelUV.y);

                Debug.DrawRay(hit.point, hit.normal, Color.red, 2f);
            }            
        }
    }

    private void DrawBrush(int x, int y)
    {
        //RenderTexture.active = renderTexture;

        // Calculate the stamp rectangle based on brush size
        int stampWidth = (int)(brushSize * brushTexture.width);
        int stampHeight = (int)(brushSize * brushTexture.height);
        Rect stampRect = new Rect(x - stampWidth / 2, y - stampHeight / 2, stampWidth, stampHeight);

        // Stamp the brush texture onto the render texture
        Graphics.DrawTexture(stampRect, brushTexture, new Rect(0, 0, 1, 1), 0, 0, 0, 0, brushColor);

        RenderTexture.active = null;

        // Update the material with the new texture
        cylinderMaterial.SetTexture("_BaseMap", renderTexture);

        //RenderTexture.active = renderTexture;
        //RenderTexture tempTexture = RenderTexture.GetTemporary(renderTexture.width, renderTexture.height, 0, RenderTextureFormat.ARGB32);
        //Graphics.Blit(renderTexture, tempTexture);

        //Material blitMaterial = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        //blitMaterial.SetColor("_Color", brushColor);
        //blitMaterial.SetTexture("_MainTex", brushTexture);

        //float aspectRatio = (float)renderTexture.width / renderTexture.height;
        //float brushSizePixels = brushSize * renderTexture.height;

        //float left = x - brushSizePixels / 2;
        //float bottom = y - brushSizePixels / 2;
        //float right = x + brushSizePixels / 2;
        //float top = y + brushSizePixels / 2;

        //float leftUV = left / renderTexture.width;
        //float bottomUV = bottom / renderTexture.height;
        //float rightUV = right / renderTexture.width;
        //float topUV = top / renderTexture.height;

        //Rect blitRect = new Rect(leftUV, 1 - topUV, rightUV - leftUV, topUV - bottomUV);

        //Graphics.Blit(tempTexture, renderTexture, blitMaterial, 0);
        //RenderTexture.ReleaseTemporary(tempTexture);

        //cylinderMaterial.SetTexture("_BaseMap", renderTexture);
    }
}
