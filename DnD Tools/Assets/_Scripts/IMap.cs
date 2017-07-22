using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Interfaces
{
    public interface IMap : IEnumerable<ITile>
    {
        int canUnitPassTile(int x, int y, ICharacter character, int movesLeftInTurn);
    }
}
