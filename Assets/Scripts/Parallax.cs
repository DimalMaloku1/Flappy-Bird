using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float animationSpeed = 1f;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();  
    }
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
// ky komponent eshte qe te bejme backgroundin levizese 
