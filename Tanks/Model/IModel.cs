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
