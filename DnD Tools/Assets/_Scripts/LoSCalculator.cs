using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoSCalculator : MonoBehaviour {
    public GameObject A;
    public GameObject B;

    private Vector3 CalculateClosestCorner(Transform caster, Transform target) {
        Vector3 temp = new Vector3();
        Vector3 dif = caster.position - target.position;

        if (dif.x > 0)
            temp.x = (caster.position.x + (caster.lossyScale.x / 2));
        else
            temp.x = (caster.position.x - (caster.lossyScale.x / 2));

        if (dif.y > 0)
            temp.y = (caster.position.y + (caster.lossyScale.y / 2));
        else
            temp.y = (caster.position.y - (caster.lossyScale.y / 2));

        if (dif.z > 0)
            temp.z = (caster.position.z + (caster.lossyScale.z / 2));
        else
            temp.z = (caster.position.z - (caster.lossyScale.z / 2));

        return temp;
    }

    public bool CalculateLineofSight(Transform caster, Transform target) {
        Vector3 castOrigin;
        castOrigin = CalculateClosestCorner(caster, target);

        return false;
    }

    public float CalculateCover(Transform a, Transform target) {
        Vector3 castOrigin;
        castOrigin = CalculateClosestCorner(a, target);

        return 1;
    }

    void Start() {
        //CalculateLineofSight(A.transform, B.transform);
    }
}
