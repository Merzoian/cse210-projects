public abstract class Goal
{
    public string Description { get; set; }
    public int Score { get; set; }
    public bool Completed { get; set; }

    public Goal(string description, int score, bool completed)
    {
        Description = description;
        Score = score;
        Completed = completed;
    }

    public abstract void UpdateScore();
    public abstract string DisplayStatus();




    public class SimpleGoal : Goal
{
    public SimpleGoal(string description, int score, bool completed) : base(description, score, completed)
    {
    }

    public override void UpdateScore()
    {
        if (!Completed)
        {
            Score = 10;
            Completed = true;
        }
    }

    public override string DisplayStatus()
    {
        return Completed? "[X]" : "[ ]";
    }
}
}