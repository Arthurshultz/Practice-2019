using Model.GameObjects;
using System.Collections.Generic;

namespace Model
{
    public interface IModelView
    {
        IEnumerable<GameObject> GameObjects { get; }
        int Score { get; }
        bool GameOver { get; }
    }
}
