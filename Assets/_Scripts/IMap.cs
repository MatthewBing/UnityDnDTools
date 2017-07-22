using System.Collections.Generic;
namespace Assets.Interfaces
{
    public interface IMap : IEnumerable<ITile>
    {
        int canUnitPassTile(int x, int y, ICharacter character, int movesLeftInTurn);
    }
}
