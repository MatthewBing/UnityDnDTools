using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Interfaces
{
    public interface IMap
    {
        bool canUnitPassTile(int x, int y, ICharacter character);
    }
}
