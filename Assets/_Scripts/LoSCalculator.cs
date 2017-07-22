using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoSCalculator : MonoBehaviour {
    public GameObject A;
    public GameObject B;
    public LayerMask layermask;

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

    public float CalculateCoverandLoS(Transform caster, Transform target) {
        Vector3 castOrigin;
        int casthits = 0;
        castOrigin = CalculateClosestCorner(caster, target);
        //centercast
        if (Physics.Raycast(castOrigin, target.position, layermask)) {
            casthits++;
        }
        //close
        //if (Physics.Raycast(castOrigin,)
        //left

        //right

        //far
        return 0;
    }

    void Start() {
        //CalculateCoverandLoS(A.transform, B.transform);
    }
}
