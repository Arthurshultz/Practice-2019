using Model.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Direction { Up, Right, Down, Left, None }
namespace Model
{
    public interface IModel
    {

        Direction Direction { get; set; }

        void NewGame();
        void Update();
        void KolobokShoot();
    }

}
