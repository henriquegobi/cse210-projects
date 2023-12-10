namespace Develop05
{
    public abstract class Goal
    {
        protected string _description;

        public Goal(string description)
        {
            _description = description;
        }
        public Goal()
        {
        }

        public string GetDescription()
        {
            return _description;
        }

        public virtual void UpDateGoal()
        {
            
        }
        public abstract int ReturnPoints();

        public abstract void DisplayGoal();
    }
}