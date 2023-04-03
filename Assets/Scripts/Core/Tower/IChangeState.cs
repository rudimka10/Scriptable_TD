namespace Core.Tower
{
    public interface IChangeState
    {
        public void SetState(SpotState spotState);
        public void SetState(TowerType towerType);
    }
}