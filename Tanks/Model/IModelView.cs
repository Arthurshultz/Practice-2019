using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IModelView
    {
        IEnumerable<GameObject> GameObjects { get; }
        int Score { get; }
        bool GameOver { get; }
    }
}
