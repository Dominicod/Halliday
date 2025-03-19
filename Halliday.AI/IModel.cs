namespace Halliday.AI;

public interface IModel
{
    public List<Tuple<string, double>> Evaluate(string label);
}