using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector3 pos, dir;

    GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndices = new List<Vector3>();

    public LaserBeam(Vector3 pos, Vector3 dir, Material material)
    {
        this.laserObj = new GameObject("Laser Beam");
        this.laser = this.laserObj.AddComponent<LineRenderer>();

        this.pos = pos;
        this.dir = dir;

        this.laser.startWidth = 0.5f;
        this.laser.endWidth = 0.5f;
        this.laser.material = material;

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        laserIndices.Add(pos);
        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50, 1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(50));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        laser.positionCount = laserIndices.Count;
        for (int i = 0; i < laserIndices.Count; i++)
        {
            laser.SetPosition(i, laserIndices[i]);
        }
    }

    void CheckHit(RaycastHit hitInfo, Vector3 direction, LineRenderer laser)
    {
        if (hitInfo.collider.CompareTag("Mirror"))
        {
            Vector3 pos = hitInfo.point;
            Vector3 dir = Vector3.Reflect(direction, hitInfo.normal);
            CastRay(pos, dir, laser);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }

        if (hitInfo.collider.CompareTag("Reciever"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MapMenu");
        }
    }
}
