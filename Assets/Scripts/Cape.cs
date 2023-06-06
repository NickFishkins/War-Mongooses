using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cape : MonoBehaviour
{
    private int length = 20; // Length of fabric
    private int width = 7; // Width of fabric
    public Vector2 globalAccel = Vector2.zero; // Global acceleration
    private List<Vector2> accel = new List<Vector2>(); // Acceleration list
    private List<Vector2> pos = new List<Vector2>(); // Position list
    private List<Vector2> prevPos = new List<Vector2>(); // Previous position list
    public float radius = 0.25f; // Distance between points
    public List<GameObject> pins = new List<GameObject>(); // Pin objects
    public float floor = -7.89f; // Floor position
    public float randomRange = 0; // Random acceleration range
    public float randomAmmount = 0; // Random acceleration ammount
    private Mesh mesh; // Mesh
    private MeshFilter meshFilter; // Mesh filter
    public GameObject player;

    private Vector2 startPos;
    void Start() {
        startPos = transform.position;
        // ***** Make lists *****
        int i = 0;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < length; y++) {
                accel.Add(new Vector2(0, 0));
                Vector2 vec = new Vector2(0 + x * radius, 0 + y * radius);
                pos.Add(vec);
                prevPos.Add(vec);
                i++;
            }
        }
        // ***** End *****
        meshFilter = GetComponent<MeshFilter>(); // Get mesh filter
        mesh = new Mesh();
        UpdateVerts(); // Update vertices
        UpdateTris(); // Update triangles
        meshFilter.mesh = mesh; // Set the mesh filter's mesh to the mesh object
        mesh.RecalculateNormals(); // Update mesh normals
    }
    void Update() {
        for (int i = 0; i < length * width; i++) { // Loops through points
            Vector2 veloc = pos[i] - prevPos[i]; // Velocity
            prevPos[i] = pos[i]; // Adjust previous position
            if (pos[i].y == floor) { // Friction on floor
                veloc *= new Vector2(0.9f, 1);
            }
            Vector2 acceleration = accel[i] + globalAccel; // Acceleration

            // ***** Add randomness to global acceleration *****
            float num = Vector2.SignedAngle(Vector2.zero, globalAccel) + Random.Range(-randomRange, randomRange);
            Vector2 randAccel = new Vector2(Mathf.Cos(num), Mathf.Sin(num)) * globalAccel.sqrMagnitude * randomAmmount;
            acceleration += randAccel;
            // ***** End *****

            pos[i] += veloc + (Time.deltaTime * acceleration); // Adjust positions

            for (int ii = 0; ii < 10; ii++) { // Loop through point adjustment multiple times
                float dist = 0; // Distance variable

                // ***** Adjust point positions based on order in list *****
                if (i < length) {
                    if (i != 0) {
                        dist = Vector2.Distance(pos[i], pos[i - 1]);
                        pos[i] += (radius - dist) * (pos[i] - pos[i - 1]).normalized / 2;
                        pos[i - 1] += (radius - dist) * (pos[i - 1] - pos[i]).normalized / 2;
                    }
                } else {
                    dist = Vector2.Distance(pos[i], pos[i - length]);
                    pos[i] += (radius - dist) * (pos[i] - pos[i - length]).normalized / 2;
                    pos[i - length] += (radius - dist) * (pos[i - length] - pos[i]).normalized / 2;
                    if (i % length != 0) {
                        dist = Vector2.Distance(pos[i], pos[i - 1]);
                        pos[i] += (radius - dist) * (pos[i] - pos[i - 1]).normalized / 2;
                        pos[i - 1] += (radius - dist) * (pos[i - 1] - pos[i]).normalized / 2;
                    }
                }
                // ***** End *****

                for (int iii = 0; iii < width; iii++) { // Adjust pins
                    pos[(0 + iii * length)] = pins[iii].transform.position;
                }
                
                if (pos[i].y < floor) { // Floor collisions
                    pos[i] = new Vector2(pos[i].x, pos[i].y + Mathf.Abs(floor - pos[i].y));
                }
            }
        }
        UpdateVerts(); // Update vertices
        mesh.RecalculateNormals(); // Update mesh normals
    }
    void UpdateTris() { // Update mesh triangles
        int[] tris = new int[12 * (length - 1) * (width - 1)]; // Array of triangles

        // ***** Configure triangles and add them to triangles array *****
        int i = 0;
        int ii = 0;
        for (int x = 0; x < width - 1; x++) {
            for (int y = 0; y < length - 1; y++) {
                tris[ii] = i;
                tris[ii + 1] = i + length;
                tris[ii + 2] = i + length + 1;
                tris[ii + 3] = i + length + 1;
                tris[ii + 4] = i + 1;
                tris[ii + 5] = i;

                tris[ii + 6] = i;
                tris[ii + 7] = i + 1;
                tris[ii + 8] = i + length + 1;
                tris[ii + 9] = i + length + 1;
                tris[ii + 10] = i + length;
                tris[ii + 11] = i;

                i++;
                ii += 12;
            }
            i++;
        }
        // ***** End *****

        mesh.triangles = tris; // Set mesh triangles to triangles array
    }
    void UpdateVerts() { // Update mesh vertices
        Vector3[] verts = new Vector3[length * width]; // Array of vertices

        // ***** Convert pos vector2's into vector3's and add them to vertices array
        for (int i = 0; i < length * width; i++) {
            Vector3 vec = new Vector3(startPos.x - pos[i].x + player.transform.position.x, startPos.x - pos[i].y + player.transform.position.y, 0);
            verts[i] = vec;
        }
        // ***** End *****

        mesh.vertices = verts; // Set mesh vertices to vertices array
    }
}