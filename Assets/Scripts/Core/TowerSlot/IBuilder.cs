using Core.Tower;

namespace Core.TowerSlot
{
    public interface IBuilder
    {
        public void AskBuild(TowerType towerType);
        public bool CanBuild(TowerType towerType);
    }
}