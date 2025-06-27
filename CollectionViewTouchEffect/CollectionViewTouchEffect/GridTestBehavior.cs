namespace CollectionViewTouchEffect;

public class GridTestBehavior: Behavior<Grid>
{
    private TapGestureRecognizer? _tapGestureRecognizer;
    
    protected override void OnAttachedTo(Grid grid)
    {
        if (_tapGestureRecognizer is null)
        {
            _tapGestureRecognizer = new TapGestureRecognizer();
            _tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (s is Grid tappedGrid && tappedGrid.BindingContext is string str)
                {
                    Console.WriteLine($"Grid tapped: {str}");
                }
            };
        }

        grid.GestureRecognizers.Add(_tapGestureRecognizer);
        base.OnAttachedTo(grid);
    }

    protected override void OnDetachingFrom(Grid grid)
    {
        if (_tapGestureRecognizer != null)
        {
            grid.GestureRecognizers.Remove(_tapGestureRecognizer);
        }
        _tapGestureRecognizer = null;
        base.OnDetachingFrom(grid);
    }
}