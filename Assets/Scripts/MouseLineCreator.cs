using UnityEngine;
using System.Collections;

public class MouseLineCreator : MonoBehaviour {

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;

    private GameObject lineObject;
    private LineRenderer line;
    private int numberOfPoints = 0;
    // Use this for initialization
    void Start()
    {
        lineObject = new GameObject("Line");
        lineObject.AddComponent<LineRenderer>();
        line = lineObject.GetComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Mobile/Particles/Additive"));
        line.SetColors(c1, c2);
        line.SetWidth(0.1F, 0);
        line.SetVertexCount(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            numberOfPoints++;
            line.SetVertexCount(numberOfPoints);
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15);
            mousePos = Input.mousePosition;
            mousePos.z = 15f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            line.SetPosition(numberOfPoints - 1, worldPos);

            BoxCollider bc = lineObject.AddComponent<BoxCollider>();
            bc.transform.position = line.transform.position;
            bc.size = new Vector3(5f, 5f, 5f);
        }
        else
        {
            numberOfPoints = 0;
            line.SetVertexCount(0);


            BoxCollider[] lineColliders = lineObject.GetComponents<BoxCollider>();

            foreach (BoxCollider b in lineColliders)
            {
                Destroy(b);
            }
        }
    }
}
