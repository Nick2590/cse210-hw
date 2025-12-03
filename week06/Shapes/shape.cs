public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Base method — overridden in derived classes
    public virtual double GetArea()
    {
        return 0; // Default placeholder
    }
}
